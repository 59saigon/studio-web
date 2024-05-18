using NM.Studio.Domain.Entities.Bases;
using NM.Studio.Domain.Entities.Events;
using System.ComponentModel.DataAnnotations.Schema;

namespace NM.Studio.Domain.Entities.Locations
{
    [Table("Location")]
    public class Location : BaseEntity
    {
        [Column(TypeName = "nvarchar(255)")]
        public string LocationName { get; set; }
        
        [ForeignKey("City")]
        public Guid CityId { get; set; }
        
        public virtual City City { get; set; }
        public virtual IList<Event> Events { get; set; }
    }
}
