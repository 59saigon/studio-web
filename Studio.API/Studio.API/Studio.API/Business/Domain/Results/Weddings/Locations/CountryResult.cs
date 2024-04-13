using Studio.API.Business.Domain.Entities.Weddings.Locations;
using Studio.API.Business.Domain.Results.Bases;

namespace Studio.API.Business.Domain.Results.Weddings.Locations
{
    public class CountryResult : BaseResult
    {
        public string Country_Name { get; set; }

        public IList<CityResult> Citys { get; set; }
    }
}
