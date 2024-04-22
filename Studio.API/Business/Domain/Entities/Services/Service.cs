using System.ComponentModel.DataAnnotations.Schema;
using Studio.API.Business.Domain.Entities.Bases;
using Studio.API.Business.Domain.Entities.Events;

namespace Studio.API.Business.Domain.Entities.Services;
[Table("Service")]
public class Service : BaseEntity
{
    [Column(TypeName = "nvarchar(255)")]
    public string ServiceTittle { get; set; }
    
    [Column(TypeName = "nvarchar(255)")]
    public string? ServiceDescription { get; set; } 
    
    [ForeignKey("Event")]
    public Guid EventId { get; set; }
    
    public string? Type { get; set; }
    
    public double Price { get; set; }
    
    public string? Status { get; set; }

    
    public virtual Event Event { get; set; }
}