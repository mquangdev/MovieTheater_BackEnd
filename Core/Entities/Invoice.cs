using Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Invoice : BaseEntity
    {
        [Required]
        public int AddScore { get; set; } 

        [Required]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; } // Date of booking

        [Required]
        [StringLength(100)]
        public string MovieName { get; set; } // Name of the movie

        [Required]
        public DateOnly ScheduleShow { get; set; }

        [Required]
        public string ScheduleShowTime { get; set; } 

        [Required]
        public int Status { get; set; } // Status of the invoice (e.g., Paid, Pending)

        [Required]
        [Column(TypeName = "decimal(18,2)")] // Specify decimal type with precision
        public decimal TotalMoney { get; set; } // Total amount of money for the invoice

        public int UseScore { get; set; } // Score used for discount, if applicable

        [Required]
        [StringLength(255)]
        public string Seat { get; set; } // Seat number(s) booked

        public Guid AccountId { get; set; }
        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }
    }
}