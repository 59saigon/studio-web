using MediatR;
using NM.Studio.Domain.Contracts.Services.Events;
using NM.Studio.Domain.CQRS.Commands.Events;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Domain.Models.Events;
using NM.Studio.Handler.Commands.Base;

namespace NM.Studio.Handler.Commands.Events
{
    public class EventCommandHandler : BaseCommandHandler<EventView>,
        IRequestHandler<EventCreateCommand, MessageView<EventView>>,
        IRequestHandler<EventUpdateCommand, MessageView<EventView>>,
        IRequestHandler<EventDeleteCommand, MessageView<EventView>>
    {
        protected readonly IEventService _eventService;
        public EventCommandHandler(IEventService eventService) : base(eventService)
        {
            _eventService = eventService;
        }

        public async Task<MessageView<EventView>> Handle(EventCreateCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.CreateOrUpdate<EventView>(request);
            return msgView;
        }

        public async Task<MessageView<EventView>> Handle(EventUpdateCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.CreateOrUpdate<EventView>(request);
            return msgView;
        }

        public async Task<MessageView<EventView>> Handle(EventDeleteCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.DeleteById<EventView>(request.Id);
            return msgView;
        }
    }
}
