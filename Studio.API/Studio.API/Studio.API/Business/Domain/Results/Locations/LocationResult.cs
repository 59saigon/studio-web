
using Studio.API.Business.Domain.Results.Bases;
using Studio.API.Business.Domain.Results.Events;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.Results.Locations
{
    public class LocationResult : BaseResult
    {
        public string LocationName { get; set; }
        
        public Guid CityId { get; set; }
        
        public CityResult City { get; set; }
        public IList<EventResult> Events { get; set; }
    }
}
