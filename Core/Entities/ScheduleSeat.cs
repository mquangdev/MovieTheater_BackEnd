using Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class ScheduleSeat : BaseEntity
    {
        public Guid MovieId { get; set; }       // Foreign key to Movie

        public Guid ScheduleId { get; set; }     // Foreign key to Schedule

        public Guid SeatId { get; set; }         // Foreign key to Seat

        public string? SeatColumn { get; set; }

        [Range(1, int.MaxValue)]
        public int SeatRow { get; set; }         // Seat row number

        public int SeatStatus { get; set; }   // Status of the seat (e.g., "Available", "Booked")

        // Navigation properties
        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; }
        [ForeignKey(nameof(ScheduleId))]
        public virtual Schedule Schedule { get; set; }
        [ForeignKey(nameof(SeatId))]
        public virtual Seat Seat { get; set; }
    }
}