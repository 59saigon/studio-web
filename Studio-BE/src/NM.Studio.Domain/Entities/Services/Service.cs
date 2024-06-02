using System.ComponentModel.DataAnnotations.Schema;
using NM.Studio.Domain.Entities.Bases;
using NM.Studio.Domain.Entities.Events;

namespace NM.Studio.Domain.Entities.Services;
[Table("Service")]
public class Service : BaseEntity
{
    [Column(TypeName = "nvarchar(255)")]
    public string ServiceTittle { get; set; }
    
    [Column(TypeName = "nvarchar(255)")]
    public string? ServiceDescription { get; set; } 
    
    public string? Type { get; set; }
    
    public double Price { get; set; }
    
    public string? Status { get; set; }

    public virtual IList<EventXService> EventXServices { get; set; }
}