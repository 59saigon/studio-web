using Studio.API.Business.Domain.Entities.Events;
using Studio.API.Business.Domain.Entities.Photos;
using Studio.API.Business.Domain.Results.Bases;
using Studio.API.Business.Domain.Results.Photos;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.Results.Events
{
    public class EventXPhotoResult : BaseResult
    {
        public Guid? EventId { get; set; }

        public Guid? PhotoId { get; set; }

        public EventResult Event { get; set; }

        public PhotoResult Photo { get; set; }
    }
}
