using MediatR;
using Studio.API.Business.Domain.Contracts.Services.Events;
using Studio.API.Business.Domain.CQRS.Queries.Events.EventXServices;
using Studio.API.Business.Domain.Models.Events;
using Studio.API.Business.Domain.Results.Events;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Handler.Queries.Base;

namespace Studio.API.Business.Handler.Queries.Events
{
    public class EventXServiceQueryHandler : BaseQueryHandler<EventXServiceView>,
        IRequestHandler<EventXServiceGetAllQuery, MessageResults<EventXServiceResult>>,
        IRequestHandler<EventXServiceGetByIdQuery, MessageResult<EventXServiceResult>>
    {
        protected readonly IEventXServiceService _eventXServiceService;
        public EventXServiceQueryHandler(IEventXServiceService eventXServiceService) : base(eventXServiceService)
        {
            _eventXServiceService = eventXServiceService;
        }

        public Task<MessageResults<EventXServiceResult>> Handle(EventXServiceGetAllQuery request, CancellationToken cancellationToken)
        {
            return _baseService.GetAll<EventXServiceResult>();
        }

        public Task<MessageResult<EventXServiceResult>> Handle(EventXServiceGetByIdQuery request, CancellationToken cancellationToken)
        {
            return _eventXServiceService.GetByEventIdAndServiceId(request);
        }
    }
}
