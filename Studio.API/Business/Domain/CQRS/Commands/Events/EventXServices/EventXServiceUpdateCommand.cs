using Studio.API.Business.Domain.CQRS.Commands.Base;
using Studio.API.Business.Domain.Models.Events;

namespace Studio.API.Business.Domain.CQRS.Commands.Events.EventXServices
{
    public class EventXServiceUpdateCommand : UpdateCommand<EventXServiceView>
    {
        public Guid? EventId { get; set; }

        public Guid? ServiceId { get; set; }

        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
