using MediatR;
using Studio.API.Business.Domain.Contracts.Services.Events;
using Studio.API.Business.Domain.CQRS.Commands.Events;
using Studio.API.Business.Domain.Models.Messages;
using Studio.API.Business.Domain.Models.Events;
using Studio.API.Business.Handler.Commands.Base;

namespace Studio.API.Business.Handler.Commands.Events
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
