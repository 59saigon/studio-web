using NM.Studio.Domain.Entities.Events;
using NM.Studio.Domain.Results.Bases;
using NM.Studio.Domain.Results.Events;

namespace NM.Studio.Domain.Results.Photos;

public class PhotoResult : BaseResult
{
    public string? PhotoName { get; set; }
    
    public string Url { get; set; }

    public IList<EventXPhotoResult> EventXPhotos { get; set; }
}