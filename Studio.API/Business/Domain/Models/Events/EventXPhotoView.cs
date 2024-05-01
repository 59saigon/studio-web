using Studio.API.Business.Domain.Entities.Events;
using Studio.API.Business.Domain.Entities.Photos;
using Studio.API.Business.Domain.Models.Base;
using Studio.API.Business.Domain.Models.Photos;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.Models.Events
{
    public class EventXPhotoView : BaseView
    {
        public Guid? EventId { get; set; }

        public Guid? PhotoId { get; set; }

    } 
}
