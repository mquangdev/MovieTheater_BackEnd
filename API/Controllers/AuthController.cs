using Application.Exceptions;
using Application.Handler.Auth.Commands.Login;
using Application.Handler.Auth.Commands.RefreshToken;
using Application.Helpers;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
            catch (Exception ex) {
            
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand request)
        {
            var result = _mediator.Send(request);
            return Ok(result.Result);
        }
    }
}
