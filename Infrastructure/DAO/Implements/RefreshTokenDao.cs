using Core.Entities;
using Infrastructure.DAO.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DAO.Implements
{
    public class RefreshTokenDao : IRefreshTokenDao
    {
        private readonly MovieTheaterContext _context;
        private readonly IConfiguration _configuration;
        public RefreshTokenDao(MovieTheaterContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<RefreshToken> GetByTokenAsync(string token)
        {
            // Get valid refresh token
            return await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == token && !x.IsRevoked && x.ExpiresAt > DateTime.UtcNow);
        }

        public async Task RevokeTokenAsync(RefreshToken refreshToken)
        {
            refreshToken.IsRevoked = true;
            await _context.SaveChangesAsync();
        }

        public async Task<RefreshToken> AddAsync(string refreshToken, Guid userId)
        {
            var refreshTokenEntity = new RefreshToken
            {
                AccountId = userId,
                Token = refreshToken,
                ExpiresAt = DateTime.Now.AddDays(double.Parse(_configuration["JwtSettings:RefreshTokenExpiration"])), // Set an appropriate expiration
                IsRevoked = false,
                CreatedAt = DateTime.Now,
            };
            _context.RefreshTokens.Add(refreshTokenEntity);
            await _context.SaveChangesAsync();
            return refreshTokenEntity;
        }

        public async Task<RefreshToken?> checkRefreshToken(Guid accountId, string refreshToken)
        {
            var storedRefreshToken = await _context.RefreshTokens
            .FirstOrDefaultAsync(rt => rt.AccountId == accountId && rt.Token == refreshToken && !rt.IsRevoked && rt.ExpiresAt > DateTime.Now);
            return storedRefreshToken;
        }
    }
}