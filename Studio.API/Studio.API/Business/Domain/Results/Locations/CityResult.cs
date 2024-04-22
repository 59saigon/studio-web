using Studio.API.Business.Domain.Results.Bases;
using System.ComponentModel.DataAnnotations.Schema;
namespace Studio.API.Business.Domain.Results.Locations
{
    public class CityResult : BaseResult
    {
        public string CityName { get; set; }
        
        public Guid CountryId { get; set; }

        public CountryResult Country { get; set; }
        
        public IList<LocationResult> Locations { get; set; }
    }
}
