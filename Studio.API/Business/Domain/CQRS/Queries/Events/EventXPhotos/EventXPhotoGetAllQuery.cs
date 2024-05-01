using Studio.API.Business.Domain.CQRS.Queries.Base;
using Studio.API.Business.Domain.Results.Events;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.CQRS.Queries.Events.EventXPhotos
{
    public class EventXPhotoGetAllQuery : GetAllQuery<EventXPhotoResult>
    {
        public Guid? EventId { get; set; }

        public List<Guid>? PhotoIds { get; set; }
    }
}
