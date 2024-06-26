﻿using MediatR;
using NM.Studio.Domain.Contracts.Services.Photos;
using NM.Studio.Domain.CQRS.Queries.Photos;
using NM.Studio.Domain.Models.Photos;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Results.Photos;
using NM.Studio.Handler.Queries.Base;

namespace NM.Studio.Handler.Queries.Photos
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

        public async Task<MessageResults<PhotoResult>> Handle(PhotoGetAllQuery request, CancellationToken cancellationToken)
        {
            return await _photoService.GetAll(request, cancellationToken);
        }

        public async Task<MessageResult<PhotoResult>> Handle(PhotoGetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _photoService.GetById<PhotoResult>(request.Id);
        }
    }
}
