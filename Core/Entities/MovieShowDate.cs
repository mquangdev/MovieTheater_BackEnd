using Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class MovieShowDate : BaseEntity
    {
        public Guid MovieId { get; set; } // Foreign key for Movie
        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; } // Navigation property for Movie

        public Guid ShowDateId { get; set; } // Foreign key for ShowDates
        [ForeignKey(nameof(ShowDateId))]
        public virtual ShowDate ShowDate { get; set; } // Navigation property for ShowDates
    }
}