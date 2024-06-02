using NM.Studio.Domain.Models.Base;

namespace NM.Studio.Domain.Models.Photos;

public class PhotoView : BaseView
{
    public string? PhotoName { get; set; }
    
    public string Url { get; set; }
    
}