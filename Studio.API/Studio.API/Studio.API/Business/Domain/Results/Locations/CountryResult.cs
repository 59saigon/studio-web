using Studio.API.Business.Domain.Results.Bases;

namespace Studio.API.Business.Domain.Results.Locations
{
    public class CountryResult : BaseResult
    {
        public string CountryName { get; set; }

        public IList<CityResult> Cities { get; set; }
    }
}
