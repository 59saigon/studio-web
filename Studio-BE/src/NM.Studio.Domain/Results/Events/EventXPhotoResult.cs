using NM.Studio.Domain.Entities.Events;
using NM.Studio.Domain.Entities.Photos;
using NM.Studio.Domain.Results.Bases;
using NM.Studio.Domain.Results.Photos;
using System.ComponentModel.DataAnnotations.Schema;

namespace NM.Studio.Domain.Results.Events
{
    public class EventXPhotoResult : BaseResult
    {
        public Guid? EventId { get; set; }

        public Guid? PhotoId { get; set; }

        public EventResult Event { get; set; }

        public PhotoResult Photo { get; set; }
    }
}
