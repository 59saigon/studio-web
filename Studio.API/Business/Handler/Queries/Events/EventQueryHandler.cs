using MediatR;
using Studio.API.Business.Domain.Contracts.Services.Events;
using Studio.API.Business.Domain.CQRS.Queries.Events;
using Studio.API.Business.Domain.Models.Events;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Results.Events;
using Studio.API.Business.Handler.Queries.Base;

namespace Studio.API.Business.Handler.Queries.Events
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

        public Task<MessageResults<EventResult>> Handle(EventGetAllQuery request, CancellationToken cancellationToken)
        {
            return _eventService.GetAll(cancellationToken);
        }

        public Task<MessageResult<EventResult>> Handle(EventGetByIdQuery request, CancellationToken cancellationToken)
        {
            return _eventService.GetById<EventResult>(request.Id);
        }
    }
}
