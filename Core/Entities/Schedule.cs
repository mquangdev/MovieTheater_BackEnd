using Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Schedule : BaseEntity
    {
        public TimeSpan ScheduleTime { get; set; } // Time of the schedule
        public virtual ICollection<MovieSchedule> MovieSchedules { get; set; } = new List<MovieSchedule>();
        public virtual ICollection<ScheduleSeat> ScheduleSeats { get; set; } = new List<ScheduleSeat>();
    }
}