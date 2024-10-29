using Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Movie : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Actor { get; set; } // Actor(s) in the movie

        [ForeignKey(nameof(CinemaRoom))]
        public Guid CinemaRoomId { get; set; } // Foreign key referencing CinemaRoom

        [Required]
        public string Content { get; set; } // Content or description of the movie

        [Required]
        [StringLength(100)]
        public string Director { get; set; } // Director of the movie

        [Required]
        public TimeSpan Duration { get; set; } // Duration of the movie

        [Required]
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; } // Release start date

        [Required]
        [StringLength(100)]
        public string MovieProductionCompany { get; set; } // Production company

        [Required]
        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; } // Release end date

        public string Version { get; set; }

        [Required]
        [StringLength(100)]
        public string MovieNameEnglish { get; set; } // Movie name in English

        [Required]
        [StringLength(100)]
        public string MovieNameVN { get; set; } // Movie name in Vietnamese

        [Required]
        public string LargeImage { get; set; } // URL or path to the large image

        [Required]
        public string SmallImage { get; set; } // URL or path to the small image

        // Optional: Navigation property for rooms where the movie has been shown
        public virtual ICollection<CinemaRoom> CinemaRooms { get; set; }
        public virtual ICollection<MovieShowDate> MovieShowDates { get; set; } = new List<MovieShowDate>();
        public virtual ICollection<MovieType> MovieTypes { get; set; } = new List<MovieType>();
    }
}