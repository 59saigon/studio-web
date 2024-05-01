using MediatR;
using Studio.API.Business.Domain.Contracts.Services.Bases;
using Studio.API.Business.Domain.Contracts.Services.Photos;
using Studio.API.Business.Domain.CQRS.Commands.Photos;
using Studio.API.Business.Domain.CQRS.Queries.Photos;
using Studio.API.Business.Domain.Models.Messages;
using Studio.API.Business.Domain.Models.Photos;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Results.Photos;
using Studio.API.Business.Handler.Commands.Base;

namespace Studio.API.Business.Handler.Commands.Photos
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
