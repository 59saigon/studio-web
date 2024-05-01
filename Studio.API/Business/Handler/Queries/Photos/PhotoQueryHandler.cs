using MediatR;
using Studio.API.Business.Domain.Contracts.Services.Photos;
using Studio.API.Business.Domain.CQRS.Queries.Photos;
using Studio.API.Business.Domain.Models.Photos;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Results.Photos;
using Studio.API.Business.Handler.Queries.Base;

namespace Studio.API.Business.Handler.Queries.Photos
{
    public class PhotoQueryHandler : BaseQueryHandler<PhotoView>,
        IRequestHandler<PhotoGetAllQuery, MessageResults<PhotoResult>>,
        IRequestHandler<PhotoGetByIdQuery, MessageResult<PhotoResult>>
    {
        protected readonly IPhotoService _photoService;
        public PhotoQueryHandler(IPhotoService photoService) : base(photoService)
        {
            _photoService = photoService;
        }

        public Task<MessageResults<PhotoResult>> Handle(PhotoGetAllQuery request, CancellationToken cancellationToken)
        {
            return _photoService.GetAll(request, cancellationToken);
        }

        public Task<MessageResult<PhotoResult>> Handle(PhotoGetByIdQuery request, CancellationToken cancellationToken)
        {
            return _photoService.GetById<PhotoResult>(request.Id);
        }
    }
}
