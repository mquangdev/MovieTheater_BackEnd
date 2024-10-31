using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Data
{
    public interface IUserIdentity
    {
        public Guid UserId { get; }
        public string Role { get; }
    }

    public class UserIdentity : IUserIdentity
    {
       
        private Guid? _userId;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserIdentity(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid UserId
        {
            get
            {
                var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return userIdClaim != null ? Guid.Parse(userIdClaim) : Guid.Empty;
            }
        }

        public string Role
        {
            get
            {
                var role = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value;
                return role != null ? role : string.Empty;
            }
        }
    }
}