
using NM.Studio.Domain.Results.Bases;
using NM.Studio.Domain.Results.Events;
using System.ComponentModel.DataAnnotations.Schema;

namespace NM.Studio.Domain.Results.Locations
{
    public class LocationResult : BaseResult
    {
        public string LocationName { get; set; }
        
        public Guid CityId { get; set; }
        
        public CityResult City { get; set; }
        public IList<EventResult> Events { get; set; }
    }
}
