using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models.Events;
using System.ComponentModel.DataAnnotations.Schema;

namespace NM.Studio.Domain.CQRS.Commands.Events.EventXPhotos
{
    public class EventXPhotoDeleteCommand : DeleteCommand<EventXPhotoView>
    {
        public Guid? EventId { get; set; }

        public Guid? PhotoId { get; set; }
    }
}
