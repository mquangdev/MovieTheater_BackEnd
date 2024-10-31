using Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class MovieType : BaseEntity
    {
        public Guid MovieId { get; set; } // Foreign key for Movie
        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; } // Navigation property for Movie

        public Guid TypeId { get; set; } // Foreign key for Type
        [ForeignKey(nameof(TypeId))]
        public virtual TypeEntity TypeEntity { get; set; } // Navigation property for Type
    }
}