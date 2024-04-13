using Studio.API.Business.Domain.Entities.Weddings.Events;
using Studio.API.Business.Domain.Results.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.Results.Weddings.Events
{
    public class Event_ImageResult : BaseResult
    {
        public string Event_Image_Name { get; set; }
        public string Event_Image_Url { get; set; }
        [ForeignKey("_Event")]
        public Guid Event_Id { get; set; }

        public EventResult _Event { get; set; }
    }
}
