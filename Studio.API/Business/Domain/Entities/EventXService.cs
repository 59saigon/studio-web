using Studio.API.Business.Domain.Entities.Bases;
using Studio.API.Business.Domain.Entities.Events;
using Studio.API.Business.Domain.Entities.Locations;
using Studio.API.Business.Domain.Entities.Photos;
using Studio.API.Business.Domain.Entities.Services;
using Studio.API.Business.Domain.Entities.Weddings;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.Entities
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
