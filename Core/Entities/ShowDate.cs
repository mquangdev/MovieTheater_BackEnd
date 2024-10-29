using Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class ShowDate : BaseEntity
    {
        [Required]
        public DateTime DateShow { get; set; } // The date of the show

        [Required]
        [StringLength(100)]
        public string DateName { get; set; } // A name or description for the date

        // Navigation property for the many-to-many relationship
        public virtual ICollection<MovieShowDate> MovieShowDates { get; set; } = new List<MovieShowDate>();
    }
}