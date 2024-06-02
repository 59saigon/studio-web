using NM.Studio.Domain.Entities.Bases;
using NM.Studio.Domain.Entities.Photos;
using NM.Studio.Domain.Entities.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace NM.Studio.Domain.Entities.Events
{
    public class EventXPhoto : BaseEntity
    {
        [ForeignKey("Event")]
        public Guid? EventId { get; set; }

        [ForeignKey("Photo")]
        public Guid? PhotoId { get; set; }

        public virtual Event Event { get; set; }

        public virtual Photo Photo { get; set; }
    }
}
