using NM.Studio.Domain.Entities.Events;
using NM.Studio.Domain.Entities.Photos;
using NM.Studio.Domain.Models.Base;
using NM.Studio.Domain.Models.Photos;
using System.ComponentModel.DataAnnotations.Schema;

namespace NM.Studio.Domain.Models.Events
{
    public class EventXPhotoView : BaseView
    {
        public Guid? EventId { get; set; }

        public Guid? PhotoId { get; set; }

    } 
}
