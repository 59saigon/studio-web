using Studio.API.Business.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.Models.Events
{
    public class EventView : BaseView
    {
        public string Event_name { get; set; }
        public Guid Wedding_Id { get; set; }
        public Guid Location_Id { get; set; }
    }
}
