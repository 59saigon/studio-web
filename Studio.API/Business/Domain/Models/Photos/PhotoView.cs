using Studio.API.Business.Domain.Models.Base;

namespace Studio.API.Business.Domain.Models.Photos;

public class PhotoView : BaseView
{
    public string? PhotoName { get; set; }
    
    public string Url { get; set; }
    
}