using Studio.API.Business.Domain.Results.Bases;

namespace Studio.API.Business.Domain.Results.Locations
{
    public class CountryResult : BaseResult
    {
        public string Country_Name { get; set; }

        public IList<CityResult> Citys { get; set; }
    }
}
