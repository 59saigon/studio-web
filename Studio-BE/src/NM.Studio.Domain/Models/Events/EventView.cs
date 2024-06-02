using NM.Studio.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NM.Studio.Domain.Models.Events
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
