using Core.Entities.Base;

namespace Core.Entities
{
    public class Role : BaseEntity
    {
        public string RoleName { get; set; }
        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>(); // Initialize to avoid null reference
    }
}