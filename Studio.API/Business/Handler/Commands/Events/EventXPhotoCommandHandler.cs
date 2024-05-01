using MediatR;
using Studio.API.Business.Domain.Contracts.Services.Events;
using Studio.API.Business.Domain.CQRS.Commands.Events.EventXPhotos;
using Studio.API.Business.Domain.Models.Events;
using Studio.API.Business.Domain.Models.Messages;
using Studio.API.Business.Handler.Commands.Base;

namespace Studio.API.Business.Handler.Commands.Events
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
