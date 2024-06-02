using NM.Studio.Domain.Entities.Weddings;
using NM.Studio.Domain.Results.Bases;
using NM.Studio.Domain.Results.Locations;
using NM.Studio.Domain.Results.Photos;
using NM.Studio.Domain.Results.Services;
using NM.Studio.Domain.Results.Weddings;

namespace NM.Studio.Domain.Results.Events
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
