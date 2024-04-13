using Studio.API.Business.Domain.Entities.Weddings.Locations;
using Studio.API.Business.Domain.Results.Bases;
using System.ComponentModel.DataAnnotations.Schema;
namespace Studio.API.Business.Domain.Results.Weddings.Locations
{
    public class CityResult : BaseResult
    {
        public string City_Name { get; set; }
        public Guid Country_Id { get; set; }

        public CountryResult _Country { get; set; }
        public IList<LocationResult> Locations { get; set; }
    }
}
