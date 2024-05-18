using MediatR;
using NM.Studio.Domain.Contracts.Services.Events;
using NM.Studio.Domain.CQRS.Queries.Events.EventXServices;
using NM.Studio.Domain.Models.Events;
using NM.Studio.Domain.Results.Events;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Handler.Queries.Base;

namespace NM.Studio.Handler.Queries.Events
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

        public async Task<MessageResults<EventXServiceResult>> Handle(EventXServiceGetAllQuery request, CancellationToken cancellationToken)
        {
            return await _baseService.GetAll<EventXServiceResult>();
        }

        public async Task<MessageResult<EventXServiceResult>> Handle(EventXServiceGetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _eventXServiceService.GetByEventIdAndServiceId(request);
        }
    }
}
