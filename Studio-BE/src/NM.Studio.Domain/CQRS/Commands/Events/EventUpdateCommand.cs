using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models.Events;

namespace NM.Studio.Domain.CQRS.Commands.Events
{
    public class EventUpdateCommand : UpdateCommand<EventView>
    {
        public string EventTittle { get; set; }
        
        public string? EventDescription { get; set; } 
        
        public Guid? WeddingId { get; set; }
        
        public Guid? LocationId { get; set; }
        
        public string? Status { get; set; }

        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
