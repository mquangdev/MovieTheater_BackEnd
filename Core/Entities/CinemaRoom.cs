using Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class CinemaRoom : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } // Name of the cinema room

        public int SeatQuantity { get; set; } // Seating capacity of the room

        public Guid? CurrentMovieId { get; set; } // Foreign key for the currently showing movie
        [ForeignKey(nameof(CurrentMovieId))]
        public virtual Movie CurrentMovie { get; set; } // Navigation property to the current movie
    }
}