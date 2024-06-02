using NM.Studio.Domain.Entities.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace NM.Studio.Domain.Entities.Locations
{
    [Table("Country")]
    public class Country : BaseEntity
    {
        [Column(TypeName = "nvarchar(255)")]
        public string CountryName { get; set; }

        public virtual IList<City> Cities { get; set; }
    }
}
