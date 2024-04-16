using Studio.API.Business.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.Models.Events
{
    public class Event_ImageView : BaseView
    {
        public string Event_Image_Name { get; set; }
        public string Event_Image_Url { get; set; }
        public Guid Event_Id { get; set; }
    }
}
