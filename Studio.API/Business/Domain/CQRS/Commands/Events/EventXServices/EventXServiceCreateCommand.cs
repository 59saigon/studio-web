using Studio.API.Business.Domain.CQRS.Commands.Base;
using Studio.API.Business.Domain.Entities.Events;
using Studio.API.Business.Domain.Entities.Services;
using Studio.API.Business.Domain.Models.Events;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.CQRS.Commands.Events.EventXServices
{
    public class EventXServiceCreateCommand : CreateCommand<EventXServiceView>
    {
        public Guid? EventId { get; set; }

        public Guid? ServiceId { get; set; }

        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
