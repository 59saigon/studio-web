using Studio.API.Business.Domain.Entities.Bases;
using Studio.API.Business.Domain.Entities.Photos;
using Studio.API.Business.Domain.Entities.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.Entities.Events
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
