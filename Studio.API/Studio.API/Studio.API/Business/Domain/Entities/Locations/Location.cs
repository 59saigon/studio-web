using Studio.API.Business.Domain.Entities.Bases;
using Studio.API.Business.Domain.Entities.Events;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.Entities.Locations
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
