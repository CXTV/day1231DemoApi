using Demo.Application.Authentication.Commands.Register;
using Demo.Application.Authentication.Queries.Login;
using Demo.Application.Authentication;
using Demo.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController:ControllerBase
    {
        private readonly ISender _mediator;

        public AuthenticationController(ISender mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            var result = await _mediator.Send(command);

            HttpContext.Response.Headers.Add("Authorization", $"Bearer {result.Token}");

            return Ok(new { Message = "User registered successfully",  result.Token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.Response.Headers.Add("Authorization", $"Bearer {result.Token}");

            return Ok(new { Message = "User login successfully",result.Token });
        }

    }
}
