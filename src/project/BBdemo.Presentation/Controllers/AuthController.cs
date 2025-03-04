using BBdemo.Application.Features.Authentication.Login.Commands;
using BBdemo.Application.Features.Authentication.Register.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BBdemo.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var response = await mediator.Send(command);

            return Ok(response);
        }
    }
}
