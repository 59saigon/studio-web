using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models.Events;

namespace NM.Studio.Domain.CQRS.Commands.Events.EventXPhotos
{
    public class EventXPhotoCreateCommand : CreateCommand<EventXPhotoView>
    {
        public Guid? EventId { get; set; }

        public Guid? PhotoId { get; set; }

        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
