using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime InsertedAt { get; set; }
        public Guid InsertedById { get; set; }

        [ForeignKey(nameof(InsertedById))]
        public virtual Account InsertedBy { get; set; }

        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedById { get; set; }

        [ForeignKey(nameof(UpdatedById))]
        public virtual Account UpdatedBy { get; set; }
    }
}
