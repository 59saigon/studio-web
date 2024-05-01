using Studio.API.Business.Domain.Entities.Weddings;
using Studio.API.Business.Domain.Results.Bases;
using Studio.API.Business.Domain.Results.Locations;
using Studio.API.Business.Domain.Results.Photos;
using Studio.API.Business.Domain.Results.Services;
using Studio.API.Business.Domain.Results.Weddings;

namespace Studio.API.Business.Domain.Results.Events
{
    public class EventResult : BaseResult
    {
        public string EventTittle { get; set; }
        
        public string? EventDescription { get; set; } 
        
        public Guid? WeddingId { get; set; }
        
        public Guid? LocationId { get; set; }
        
        public string? Status { get; set; }

        public WeddingResult Wedding { get; set; }
        
        public LocationResult Location { get; set; }

        public IList<EventXServiceResult> EventXServices { get; set; }

        public IList<EventXPhotoResult> EventXPhotos { get; set; }
    }
}
