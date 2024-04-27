using Studio.API.Business.Domain.Entities.Events;
using Studio.API.Business.Domain.Results.Bases;
using Studio.API.Business.Domain.Results.Events;

namespace Studio.API.Business.Domain.Results.Photos;

public class PhotoResult : BaseResult
{
    public string? PhotoName { get; set; }
    
    public string Url { get; set; }

    public IList<EventXPhotoResult> EventXPhotos { get; set; }
}