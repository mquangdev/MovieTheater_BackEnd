using Application.Dtos.Authentication;
using MediatR;

namespace Application.Handler.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommand : IRequest<RefreshTokenResponseDto>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}