using NM.Studio.Domain.Entities.Locations;
using NM.Studio.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace NM.Studio.Domain.Models.Locations
{
    public class LocationView : BaseView
    {
        public string LocationName { get; set; }
        
        public Guid CityId { get; set; }
    }
}
