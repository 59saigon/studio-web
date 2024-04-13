using Studio.API.Business.Domain.Entities.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.Entities.Weddings.Events
{
    [Table("Event_Image")]
    public class Event_Image : BaseEntity
    {
        public string Event_Image_Name { get; set; }
        public string Event_Image_Url { get; set; }
        [ForeignKey("_Event")]
        public Guid Event_Id { get; set; }

        public virtual Event _Event { get; set; }
    }
}
