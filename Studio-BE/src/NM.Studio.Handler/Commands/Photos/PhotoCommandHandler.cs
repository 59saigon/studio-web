using MediatR;
using NM.Studio.Domain.Contracts.Services.Bases;
using NM.Studio.Domain.Contracts.Services.Photos;
using NM.Studio.Domain.CQRS.Commands.Photos;
using NM.Studio.Domain.CQRS.Queries.Photos;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Domain.Models.Photos;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Results.Photos;
using NM.Studio.Handler.Commands.Base;

namespace NM.Studio.Handler.Commands.Photos
{
    public class PhotoCommandHandler : BaseCommandHandler<PhotoView>,
        IRequestHandler<PhotoCreateCommand, MessageView<PhotoView>>,
        IRequestHandler<PhotoUpdateCommand, MessageView<PhotoView>>,
        IRequestHandler<PhotoDeleteCommand, MessageView<PhotoView>>
    {
        protected readonly IPhotoService _photoService;
        public PhotoCommandHandler(IPhotoService photoService) : base(photoService)
        {
            _photoService = photoService;
        }

        public async Task<MessageView<PhotoView>> Handle(PhotoCreateCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.CreateOrUpdate<PhotoView>(request);
            return msgView;
        }

        public async Task<MessageView<PhotoView>> Handle(PhotoUpdateCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.CreateOrUpdate<PhotoView>(request);
            return msgView;
        }

        public async Task<MessageView<PhotoView>> Handle(PhotoDeleteCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.DeleteById<PhotoView>(request.Id);
            return msgView;
        }
    }
}
