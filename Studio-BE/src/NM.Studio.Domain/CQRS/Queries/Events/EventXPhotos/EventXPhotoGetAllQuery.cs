using NM.Studio.Domain.CQRS.Queries.Base;
using NM.Studio.Domain.Results.Events;
using System.ComponentModel.DataAnnotations.Schema;

namespace NM.Studio.Domain.CQRS.Queries.Events.EventXPhotos
{
    public class EventXPhotoGetAllQuery : GetAllQuery<EventXPhotoResult>
    {
        public Guid? EventId { get; set; }

        public List<Guid>? PhotoIds { get; set; }
    }
}
