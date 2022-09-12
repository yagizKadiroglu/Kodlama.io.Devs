using Kodlama.io.Devs.Application.Features.Authentications.Commands.UserLogin;
using Kodlama.io.Devs.Application.Features.Authentications.Commands.UserRegister;
using Kodlama.io.Devs.Application.Features.Authentications.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
        {
            RegisteteredDto result = await Mediator.Send(registerCommand);

            return Created("", result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            LoginDto result = await Mediator.Send(loginCommand);

            return Created("", result);
        }
    }
}
