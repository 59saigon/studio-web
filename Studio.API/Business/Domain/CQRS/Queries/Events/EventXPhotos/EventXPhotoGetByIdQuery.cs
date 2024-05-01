using Studio.API.Business.Domain.CQRS.Queries.Base;
using Studio.API.Business.Domain.Results.Events;

namespace Studio.API.Business.Domain.CQRS.Queries.Events.EventXPhotos
{
    public class EventXPhotoGetByIdQuery : GetByIdQuery<EventXPhotoResult>
    {
        public Guid? EventId { get; set; }
        public Guid? PhotoId { get; set; }
    }
}
