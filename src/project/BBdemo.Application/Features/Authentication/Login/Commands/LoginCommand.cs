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

namespace BBdemo.Application.Features.Authentication.Login.Commands;

public class LoginCommand : IRequest<AccessTokenDto>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, AccessTokenDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtService _jwtService;

        public LoginCommandHandler(UserManager<User> userManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<AccessTokenDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var emailUser = await _userManager.FindByEmailAsync(request.Email);

            if (emailUser is null)
            {
                throw new NotFoundException("Email not found.");
            }

            var passwordCheck = await _userManager.CheckPasswordAsync(emailUser,request.Password);

            if (passwordCheck is false)
            {
                throw new BusinessException("Wrong password.");
            }

            AccessTokenDto token = await _jwtService.CreateTokenAsync(emailUser);

            return token;
        }
    }
}
