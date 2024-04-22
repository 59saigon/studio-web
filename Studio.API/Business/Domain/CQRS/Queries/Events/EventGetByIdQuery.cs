using Studio.API.Business.Domain.CQRS.Queries.Base;
using Studio.API.Business.Domain.Results.Events;

namespace Studio.API.Business.Domain.CQRS.Queries.Events
{
    public class EventGetByIdQuery : GetByIdQuery<EventResult>
    {
        public Guid Id { get; set; }
    }
}
