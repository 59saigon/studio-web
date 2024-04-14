using Studio.API.Business.Domain.Entities.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.Entities.Locations
{
    [Table("City")]
    public class City : BaseEntity
    {
        [Column(TypeName = "nvarchar(255)")]
        public string City_Name { get; set; }
        [ForeignKey("_Country")]
        public Guid Country_Id { get; set; }

        public virtual Country _Country { get; set; }
        public virtual IList<Location> Locations { get; set; }
    }
}
