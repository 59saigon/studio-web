using MediatR;
using NM.Studio.Domain.Contracts.Services.Events;
using NM.Studio.Domain.CQRS.Queries.Events.EventXPhotos;
using NM.Studio.Domain.Models.Events;
using NM.Studio.Domain.Results.Events;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Handler.Queries.Base;

namespace NM.Studio.Handler.Queries.Events
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

        public async Task<MessageResults<EventXPhotoResult>> Handle(EventXPhotoGetAllQuery request, CancellationToken cancellationToken)
        {
            return await _baseService.GetAll<EventXPhotoResult>();
        }

        public async Task<MessageResult<EventXPhotoResult>> Handle(EventXPhotoGetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _eventXPhotoService.GetByEventIdAndPhotoId(request);
        }
    }
}
