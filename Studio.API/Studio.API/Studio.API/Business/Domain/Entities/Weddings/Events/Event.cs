using Studio.API.Business.Domain.Entities.Bases;
using Studio.API.Business.Domain.Entities.Weddings;
using Studio.API.Business.Domain.Entities.Weddings.Locations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.Entities.Weddings.Events
{
    [Table("Event")]
    public class Event : BaseEntity
    {
        [Column(TypeName = "nvarchar(255)")]
        public string Event_name { get; set; } = null!;
        [ForeignKey("_Wedding")]
        public Guid Wedding_Id { get; set; }
        [ForeignKey("_Location")]
        public Guid Location_Id { get; set; }

        public virtual Wedding _Wedding { get; set; }
        public virtual Location _Location { get; set; }

        public virtual IList<Event_Image> Event_Images { get; set; }
        public virtual IList<Event_Service> Event_Services { get; set; }

    }
}
