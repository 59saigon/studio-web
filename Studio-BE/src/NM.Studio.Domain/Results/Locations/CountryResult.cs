using NM.Studio.Domain.Results.Bases;

namespace NM.Studio.Domain.Results.Locations
{
    public class CountryResult : BaseResult
    {
        public string CountryName { get; set; }

        public IList<CityResult> Cities { get; set; }
    }
}
