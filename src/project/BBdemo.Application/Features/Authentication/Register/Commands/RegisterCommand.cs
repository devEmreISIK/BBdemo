using BBdemo.Application.Services.JwtServices;
using BBdemo.Domain.Entities;
using Core.CrossCuttingConcernes.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBdemo.Application.Features.Authentication.Register.Command;

public class RegisterCommand : IRequest<AccessTokenDto>
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string City { get; set; }
    public string Password { get; set; }


    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AccessTokenDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtService _jwtService;

        public RegisterCommandHandler(UserManager<User> userManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<AccessTokenDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            User user = new User()
            {
                City = request.City,
                UserName = request.UserName,
                Email = request.Email,
            };

            var emailUserCheck = await _userManager.FindByEmailAsync(request.Email);

            if (emailUserCheck is not null)
            {
                // Aynı emaile sahip bir kullanıcı var mı yok mu
                throw new BusinessException("User email should be unique.");
            }

            IdentityResult result = await _userManager.CreateAsync(user, request.Password);

            //if (!result.Succeeded)
            //{
            //    var errors = result.Errors.Select(x => x.Description).ToList();
            //    throw new AuthorizationException(errors);
            //}

            if (result.Succeeded) 
            {
                AccessTokenDto token = await _jwtService.CreateTokenAsync(emailUserCheck);

                return token;

            }
            else
            {
                return new AccessTokenDto();
            }

   
        }
    }
}
