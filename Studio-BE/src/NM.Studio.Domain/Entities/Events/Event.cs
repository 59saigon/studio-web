using NM.Studio.Domain.Entities.Bases;
using NM.Studio.Domain.Entities.Locations;
using NM.Studio.Domain.Entities.Weddings;
using System.ComponentModel.DataAnnotations.Schema;
using NM.Studio.Domain.Entities.Photos;
using NM.Studio.Domain.Entities.Services;

namespace NM.Studio.Domain.Entities.Events
{
    [Table("Event")]
    public class Event : BaseEntity
    {
        [Column(TypeName = "nvarchar(255)")]
        public string EventTittle { get; set; }
        
        [Column(TypeName = "nvarchar(255)")]
        public string? EventDescription { get; set; } 
        
        [ForeignKey("Wedding")]
        public Guid? WeddingId { get; set; }
        
        [ForeignKey("Location")]
        public Guid? LocationId { get; set; }
        
        public string? Status { get; set; }

        public virtual Wedding Wedding { get; set; }
        
        public virtual Location Location { get; set; }

        public virtual IList<EventXService> EventXServices { get; set; }

        public virtual IList<EventXPhoto> EventXPhotos { get; set; }

    }
}
