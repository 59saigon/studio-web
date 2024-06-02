using NM.Studio.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NM.Studio.Domain.Models.Locations
{
    public class CityView : BaseView
    {
        public string CityName { get; set; }
        
        public Guid CountryId { get; set; }
    }
}
