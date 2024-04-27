using Studio.API.Business.Domain.Entities.Bases;
using Studio.API.Business.Domain.Entities.Locations;
using Studio.API.Business.Domain.Entities.Weddings;
using System.ComponentModel.DataAnnotations.Schema;
using Studio.API.Business.Domain.Entities.Photos;
using Studio.API.Business.Domain.Entities.Services;

namespace Studio.API.Business.Domain.Entities.Events
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
