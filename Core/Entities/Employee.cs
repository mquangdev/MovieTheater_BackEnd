using Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Employee : BaseEntity
    {
        public Guid AccountId { get; set; }
        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }
    }
}