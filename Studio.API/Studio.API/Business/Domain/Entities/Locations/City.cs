using Studio.API.Business.Domain.Entities.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.Entities.Locations
{
    [Table("City")]
    public class City : BaseEntity
    {
        [Column(TypeName = "nvarchar(255)")]
        public string CityName { get; set; }
        
        [ForeignKey("Country")]
        public Guid CountryId { get; set; }

        public virtual Country Country { get; set; }
        
        public virtual IList<Location> Locations { get; set; }
    }
}
