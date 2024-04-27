using System.ComponentModel.DataAnnotations.Schema;
using Studio.API.Business.Domain.Entities.Bases;
using Studio.API.Business.Domain.Entities.Events;

namespace Studio.API.Business.Domain.Entities.Photos;

[Table("Photo")]
public class Photo : BaseEntity
{
    public string? PhotoName { get; set; }
    
    public string Url { get; set; }
    
    public virtual IList<EventXPhoto> EventXPhotos { get; set; }
}