using NM.Studio.Domain.CQRS.Queries.Base;
using NM.Studio.Domain.Results.Events;

namespace NM.Studio.Domain.CQRS.Queries.Events.EventXPhotos
{
    public class EventXPhotoGetByIdQuery : GetByIdQuery<EventXPhotoResult>
    {
        public Guid? EventId { get; set; }
        public Guid? PhotoId { get; set; }
    }
}
