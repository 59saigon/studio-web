using NM.Studio.Domain.Entities.Bases;
using NM.Studio.Domain.Entities.Locations;
using NM.Studio.Domain.Entities.Photos;
using NM.Studio.Domain.Entities.Services;
using NM.Studio.Domain.Entities.Weddings;
using System.ComponentModel.DataAnnotations.Schema;

namespace NM.Studio.Domain.Entities.Events
{
    public class EventXService : BaseEntity
    {
        [ForeignKey("Event")]
        public Guid? EventId { get; set; }

        [ForeignKey("Service")]
        public Guid? ServiceId { get; set; }

        public virtual Event Event { get; set; }

        public virtual Service Service { get; set; }

    }
}
