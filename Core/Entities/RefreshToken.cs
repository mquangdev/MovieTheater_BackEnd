using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class RefreshToken
    {
        [Key]
        public Guid Id { get; set; }
        public string Token { get; set; }
        public Guid AccountId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsRevoked { get; set; }
    }
}