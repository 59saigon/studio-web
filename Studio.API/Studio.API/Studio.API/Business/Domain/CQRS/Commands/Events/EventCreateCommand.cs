using Studio.API.Business.Domain.CQRS.Commands.Base;
using Studio.API.Business.Domain.Models.Events;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.CQRS.Commands.Events
{
    public class EventCreateCommand : CreateCommand<EventView>
    {
        public string EventTittle { get; set; }
        
        public string? EventDescription { get; set; } 
        
        public Guid? WeddingId { get; set; }
        
        public Guid? LocationId { get; set; }
        
        public string? Status { get; set; }

        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
