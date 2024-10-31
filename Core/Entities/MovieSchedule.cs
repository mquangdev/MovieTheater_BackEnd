using Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class MovieSchedule : BaseEntity
    {
        public Guid MovieId { get; set; }
        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; }
        public Guid ScheduleId { get; set; }
        [ForeignKey(nameof(ScheduleId))]
        public virtual Schedule Schedule { get; set; }
    }
}