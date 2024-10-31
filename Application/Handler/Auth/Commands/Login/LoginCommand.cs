using Application.Dtos.Authentication;
using MediatR;

namespace Application.Handler.Auth.Commands.Login
{
    public class LoginCommand : IRequest<AuthResponseDto>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}