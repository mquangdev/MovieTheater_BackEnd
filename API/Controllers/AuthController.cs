using Application.Handler.Auth.Commands.Login;
using Application.Handler.Auth.Commands.RefreshToken;
using Application.Handler.Auth.Commands.Register;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand request)
        {
            try
            {
                var result = _mediator.Send(request);
                return Ok(result.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand request)
        {
            var result = _mediator.Send(request);
            return Ok(result.Result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand request)
        {
            var result = _mediator.Send(request);
            return Ok(result.Result);
        }
    }
}