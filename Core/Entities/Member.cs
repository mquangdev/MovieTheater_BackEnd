using Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Member : BaseEntity
    {
        public int Score { get; set; }
        public Guid AccountId { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }
    }
}