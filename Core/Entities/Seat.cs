using Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Seat : BaseEntity
    {
        public Guid CinemaRoomId { get; set; } // Foreign key for the cinema room

        [ForeignKey(nameof(CinemaRoomId))]
        public virtual CinemaRoom CinemaRoom { get; set; } // Navigation property for CinemaRoom

        [Range(1, 100)] // Adjust range as needed
        public int SeatRow { get; set; } // Row number of the seat

        public string? SeatColumn { get; set; } // Column number of the seat

        public int SeatStatus { get; set; } // Status of the seat (e.g., Available, Reserved, Occupied)

        public int SeatType { get; set; } // Type of the seat (e.g., Regular, VIP)
        public virtual ICollection<ScheduleSeat> ScheduleSeats { get; set; } = new List<ScheduleSeat>();
    }
}