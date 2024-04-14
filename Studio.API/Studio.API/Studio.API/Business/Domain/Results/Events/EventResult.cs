using Studio.API.Business.Domain.Entities.Weddings;
using Studio.API.Business.Domain.Results.Bases;
using System.ComponentModel.DataAnnotations.Schema;
using Studio.API.Business.Domain.Results.Weddings;
using Studio.API.Business.Domain.Results.Locations;

namespace Studio.API.Business.Domain.Results.Events
{
    public class EventResult : BaseResult
    {
        public string Event_name { get; set; } = null!;
        public Guid Wedding_Id { get; set; }
        public Guid Location_Id { get; set; }

        public WeddingResult _Wedding { get; set; }
        public LocationResult _Location { get; set; }

        public IList<Event_ImageResult> Event_Images { get; set; }
        public IList<Event_ServiceResult> Event_Services { get; set; }
    }
}
