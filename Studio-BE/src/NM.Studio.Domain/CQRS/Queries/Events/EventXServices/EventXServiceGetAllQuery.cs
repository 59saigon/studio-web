using NM.Studio.Domain.CQRS.Queries.Base;
using NM.Studio.Domain.Results.Events;

namespace NM.Studio.Domain.CQRS.Queries.Events.EventXServices
{
    public class EventXServiceGetAllQuery : GetAllQuery<EventXServiceResult>
    {
        public Guid? EventId { get; set; }

        public Guid? ServiceId { get; set; }
    }
}
