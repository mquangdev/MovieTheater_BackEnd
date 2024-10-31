using Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Invoice : BaseEntity
    {
        public int AddScore { get; set; } 

        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; } // Date of booking

        [StringLength(100)]
        public string? MovieName { get; set; } // Name of the movie

        public DateOnly ScheduleShow { get; set; }

        public string? ScheduleShowTime { get; set; } 

        public int Status { get; set; } // Status of the invoice (e.g., Paid, Pending)

        [Column(TypeName = "decimal(18,2)")] // Specify decimal type with precision
        public decimal TotalMoney { get; set; } // Total amount of money for the invoice

        public int UseScore { get; set; } // Score used for discount, if applicable

        [StringLength(255)]
        public string? Seat { get; set; } // Seat number(s) booked

        public Guid AccountId { get; set; }
        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}