using Studio.API.Business.Domain.CQRS.Queries.Base;
using Studio.API.Business.Domain.Results.Events;

namespace Studio.API.Business.Domain.CQRS.Queries.Events.EventXServices
{
    public class EventXServiceGetByIdQuery : GetByIdQuery<EventXServiceResult>
    {
        public Guid? EventId { get; set; }
        public Guid? ServiceId { get; set; }
    }
}
