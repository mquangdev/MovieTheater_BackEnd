using Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Movie : BaseEntity
    {
        [StringLength(100)]
        public string? Actor { get; set; } // Actor(s) in the movie

        public string? Content { get; set; } // Content or description of the movie

        [StringLength(100)]
        public string? Director { get; set; } // Director of the movie

        public TimeSpan Duration { get; set; } // Duration of the movie

        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; } // Release start date

        [StringLength(100)]
        public string? MovieProductionCompany { get; set; } // Production company

        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; } // Release end date

        public string? Version { get; set; }

        [StringLength(100)]
        public string? MovieNameEnglish { get; set; } // Movie name in English

        [StringLength(100)]
        public string? MovieNameVN { get; set; } // Movie name in Vietnamese

        public string? LargeImage { get; set; } // URL or path to the large image

        public string? SmallImage { get; set; } // URL or path to the small image

        // Optional: Navigation property for rooms where the movie has been shown
        public virtual ICollection<CinemaRoom> CinemaRooms { get; set; } = new List<CinemaRoom>();
        public virtual ICollection<MovieShowDate> MovieShowDates { get; set; } = new List<MovieShowDate>();
        public virtual ICollection<MovieType> MovieTypes { get; set; } = new List<MovieType>();
        public virtual ICollection<MovieSchedule> MovieSchedules { get; set; } = new List<MovieSchedule>();
        public virtual ICollection<ScheduleSeat> ScheduleSeats { get; set; } = new List<ScheduleSeat>();
    }
}