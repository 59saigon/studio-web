using MediatR;
using Studio.API.Business.Domain.Contracts.Services.Events;
using Studio.API.Business.Domain.CQRS.Commands.Events.EventXServices;
using Studio.API.Business.Domain.Models.Events;
using Studio.API.Business.Domain.Models.Messages;
using Studio.API.Business.Handler.Commands.Base;

namespace Studio.API.Business.Handler.Commands.Event
{
    public class EventXServiceCommandHandler : BaseCommandHandler<EventXServiceView>,
        IRequestHandler<EventXServiceCreateCommand, MessageView<EventXServiceView>>,
        IRequestHandler<EventXServiceUpdateCommand, MessageView<EventXServiceView>>,
        IRequestHandler<EventXServiceDeleteCommand, MessageView<EventXServiceView>>
    {
        protected readonly IEventXServiceService _eventXServiceService;
        public EventXServiceCommandHandler(IEventXServiceService eventXServiceService) : base(eventXServiceService)
        {
            _eventXServiceService = eventXServiceService;
        }

        public async Task<MessageView<EventXServiceView>> Handle(EventXServiceCreateCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.CreateOrUpdate<EventXServiceView>(request);
            return msgView;
        }

        public async Task<MessageView<EventXServiceView>> Handle(EventXServiceUpdateCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.CreateOrUpdate<EventXServiceView>(request);
            return msgView;
        }

        public async Task<MessageView<EventXServiceView>> Handle(EventXServiceDeleteCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.DeleteById<EventXServiceView>(request.Id);
            return msgView;
        }
    }
}
