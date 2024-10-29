using Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Type : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } // Name of the type (e.g., Action, Comedy)

        // Navigation property for the many-to-many relationship
        public virtual ICollection<MovieType> MovieTypes { get; set; } = new List<MovieType>();
    }
}