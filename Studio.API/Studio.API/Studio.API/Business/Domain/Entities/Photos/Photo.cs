using System.ComponentModel.DataAnnotations.Schema;
using Studio.API.Business.Domain.Entities.Bases;
using Studio.API.Business.Domain.Entities.Events;

namespace Studio.API.Business.Domain.Entities.Photos;

[Table("Photo")]
public class Photo : BaseEntity
{
    public string? PhotoName { get; set; }
    
    public string Url { get; set; }
    
    [ForeignKey("Event")] 
    public Guid EventId { get; set; }

    public virtual Event Event { get; set; }
}