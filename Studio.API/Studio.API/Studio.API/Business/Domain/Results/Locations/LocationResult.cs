
using Studio.API.Business.Domain.Results.Bases;
using Studio.API.Business.Domain.Results.Events;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.Results.Locations
{
    public class LocationResult : BaseResult
    {
        public string Location_Name { get; set; }
        public Guid City_Id { get; set; }
        public CityResult _City { get; set; }
        public IList<EventResult> Events { get; set; }
    }
}
