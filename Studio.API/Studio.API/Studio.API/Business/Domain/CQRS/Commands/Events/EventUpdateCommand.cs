using Studio.API.Business.Domain.CQRS.Commands.Base;
using Studio.API.Business.Domain.Models.Events;

namespace Studio.API.Business.Domain.CQRS.Commands.Events
{
    public class EventUpdateCommand : UpdateCommand<EventView>
    {
        public string Event_name { get; set; } = null!;
        public Guid Wedding_Id { get; set; }
        public Guid Location_Id { get; set; }

        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
