using Studio.API.Business.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.Models.Events
{
    public class EventView : BaseView
    {
        public string EventTittle { get; set; }
        
        public string? EventDescription { get; set; } 
        
        public Guid? WeddingId { get; set; }
        
        public Guid? LocationId { get; set; }
        
        public string? Status { get; set; }
    }
}
