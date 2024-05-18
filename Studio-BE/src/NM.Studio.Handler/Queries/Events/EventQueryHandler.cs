using MediatR;
using NM.Studio.Domain.Contracts.Services.Events;
using NM.Studio.Domain.CQRS.Queries.Events;
using NM.Studio.Domain.Models.Events;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Results.Events;
using NM.Studio.Handler.Queries.Base;

namespace NM.Studio.Handler.Queries.Events
{
    public class EventQueryHandler : BaseQueryHandler<EventView>,
        IRequestHandler<EventGetAllQuery, MessageResults<EventResult>>,
        IRequestHandler<EventGetByIdQuery, MessageResult<EventResult>>
    {
        protected readonly IEventService _eventService;
        public EventQueryHandler(IEventService eventService) : base(eventService)
        {
            _eventService = eventService;
        }

        public async Task<MessageResults<EventResult>> Handle(EventGetAllQuery request, CancellationToken cancellationToken)
        {
            return await _eventService.GetAll(cancellationToken);
        }

        public async Task<MessageResult<EventResult>> Handle(EventGetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _eventService.GetById<EventResult>(request.Id);
        }
    }
}
