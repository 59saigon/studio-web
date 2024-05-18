using System.ComponentModel.DataAnnotations.Schema;
using NM.Studio.Domain.Entities.Bases;
using NM.Studio.Domain.Entities.Events;

namespace NM.Studio.Domain.Entities.Photos;

[Table("Photo")]
public class Photo : BaseEntity
{
    public string? PhotoName { get; set; }
    
    public string Url { get; set; }
    
    public virtual IList<EventXPhoto> EventXPhotos { get; set; }
}