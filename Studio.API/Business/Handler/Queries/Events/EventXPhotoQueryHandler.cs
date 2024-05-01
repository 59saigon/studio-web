using MediatR;
using Studio.API.Business.Domain.Contracts.Services.Events;
using Studio.API.Business.Domain.CQRS.Queries.Events.EventXPhotos;
using Studio.API.Business.Domain.Models.Events;
using Studio.API.Business.Domain.Results.Events;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Handler.Queries.Base;

namespace Studio.API.Business.Handler.Queries.Events
{
    public class EventXPhotoQueryHandler : BaseQueryHandler<EventXPhotoView>,
        IRequestHandler<EventXPhotoGetAllQuery, MessageResults<EventXPhotoResult>>,
        IRequestHandler<EventXPhotoGetByIdQuery, MessageResult<EventXPhotoResult>>
    {
        protected readonly IEventXPhotoService _eventXPhotoService;
        public EventXPhotoQueryHandler(IEventXPhotoService eventXPhotoService) : base(eventXPhotoService)
        {
            _eventXPhotoService = eventXPhotoService;
        }

        public Task<MessageResults<EventXPhotoResult>> Handle(EventXPhotoGetAllQuery request, CancellationToken cancellationToken)
        {
            return _baseService.GetAll<EventXPhotoResult>();
        }

        public Task<MessageResult<EventXPhotoResult>> Handle(EventXPhotoGetByIdQuery request, CancellationToken cancellationToken)
        {
            return _eventXPhotoService.GetByEventIdAndPhotoId(request);
        }
    }
}
