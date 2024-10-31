using Core.Entities;

namespace Infrastructure.DAO.Interfaces
{
    public interface IRefreshTokenDao
    {
        Task<RefreshToken> GetByTokenAsync(string token);
        Task<RefreshToken> AddAsync(string refreshToken, Guid userId);
        Task RevokeTokenAsync(RefreshToken refreshToken);
        Task<RefreshToken?> checkRefreshToken(Guid accountId, string refreshToken);
    }
}