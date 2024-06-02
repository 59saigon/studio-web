using MediatR;
using NM.Studio.Domain.Contracts.Services.Events;
using NM.Studio.Domain.CQRS.Commands.Events.EventXPhotos;
using NM.Studio.Domain.Models.Events;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Handler.Commands.Base;

namespace NM.Studio.Handler.Commands.Events
{
    public class EventXPhotoCommandHandler : BaseCommandHandler<EventXPhotoView>,
        IRequestHandler<EventXPhotoCreateCommand, MessageView<EventXPhotoView>>,
        IRequestHandler<EventXPhotoUpdateCommand, MessageView<EventXPhotoView>>,
        IRequestHandler<EventXPhotoDeleteCommand, MessageView<EventXPhotoView>>
    {
        protected readonly IEventXPhotoService _eventXPhotoService;
        public EventXPhotoCommandHandler(IEventXPhotoService eventXPhotoService) : base(eventXPhotoService)
        {
            _eventXPhotoService = eventXPhotoService;
        }

        public async Task<MessageView<EventXPhotoView>> Handle(EventXPhotoCreateCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.CreateOrUpdate<EventXPhotoView>(request);
            return msgView;
        }

        public async Task<MessageView<EventXPhotoView>> Handle(EventXPhotoUpdateCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.CreateOrUpdate<EventXPhotoView>(request);
            return msgView;
        }

        public async Task<MessageView<EventXPhotoView>> Handle(EventXPhotoDeleteCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.DeleteById<EventXPhotoView>(request.Id);
            return msgView;
        }
    }
}
