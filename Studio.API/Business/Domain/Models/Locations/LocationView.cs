using Studio.API.Business.Domain.Entities.Locations;
using Studio.API.Business.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.Models.Locations
{
    public class LocationView : BaseView
    {
        public string LocationName { get; set; }
        
        public Guid CityId { get; set; }
    }
}
