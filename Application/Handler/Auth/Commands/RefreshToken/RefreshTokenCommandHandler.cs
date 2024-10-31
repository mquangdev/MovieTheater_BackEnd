using Application.Dtos.Authentication;
using Application.Exceptions;
using Application.Helpers;
using Infrastructure.DAO.Interfaces;
using Infrastructure.Data;
using MediatR;

namespace Application.Handler.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : BaseHandler, IRequestHandler<RefreshTokenCommand, RefreshTokenResponseDto>
    {
        private readonly IRefreshTokenDao _refreshTokenDao;
        private readonly IUserIdentity _userIdentity;
        private readonly JwtHelper _jwtHelper;

        public RefreshTokenCommandHandler(IUnitOfWork unitOfWork, IRefreshTokenDao refreshTokenDao, IUserIdentity userIdentity, JwtHelper jwtHelper) : base(unitOfWork)
        {
            _refreshTokenDao = refreshTokenDao;
            _userIdentity = userIdentity;
            _jwtHelper = jwtHelper;
        }

        public async Task<RefreshTokenResponseDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            // Extract userId from the JWT token
            var userId = _userIdentity.UserId;

            // Check if refresh token is valid and not expired or revoked
            var storedRefreshToken = await _refreshTokenDao.checkRefreshToken(userId, request.RefreshToken);
            if (storedRefreshToken == null)
            {
                throw new ArgumentException("Refresh token invalid");
            }

            // Generate new tokens
            var userRole = "Admin"; // Retrieve role from token if needed
            var newAccessToken = _jwtHelper.GenerateJwtToken(userId.ToString(), userRole);
            var newRefreshToken = _jwtHelper.GenerateRefreshToken();

            // Mark old token as revoked and add new token to the database
            storedRefreshToken.IsRevoked = true;

            // Create new refreshToken
            await _refreshTokenDao.AddAsync(newRefreshToken, userId);

            return new RefreshTokenResponseDto { AccessToken = newAccessToken, RefreshToken = newRefreshToken };
        }
    }
}