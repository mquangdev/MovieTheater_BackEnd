using Application.Dtos.Authentication;
using Application.Helpers;
using Core.Entities;
using Infrastructure.DAO.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handler.Auth.Commands.Login
{
    internal class LoginCommandHandler : BaseHandler, IRequestHandler<LoginCommand, AuthResponseDto>
    {
        private readonly JwtHelper _jwtHelper;
        private readonly IRefreshTokenDao _refreshTokenDao;

        public LoginCommandHandler(IUnitOfWork unitOfWork, JwtHelper jwtHelper, IRefreshTokenDao refreshTokenDao) : base(unitOfWork)
        {
            _jwtHelper = jwtHelper;
            _refreshTokenDao = refreshTokenDao;
        }

        public async Task<AuthResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var accountEntity = await UnitOfWork.AccountDao.GetQuery(x => x.Username == request.UsernameOrEmail || x.Email == request.UsernameOrEmail).FirstOrDefaultAsync();            if (accountEntity is not null && request.Password == accountEntity.Password)
            {
                var accessToken = _jwtHelper.GenerateJwtToken(accountEntity.Id.ToString(), accountEntity.Role.RoleName);
                var refreshToken = _jwtHelper.GenerateRefreshToken();
                await _refreshTokenDao.AddAsync(refreshToken, accountEntity.Id);
                var response = new AuthResponseDto
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    UserId = accountEntity.Id,
                    UserName = accountEntity.Username
                };
                return response;
            }
            throw new Exception("Email/Username or password wrong");
        }
    }
}