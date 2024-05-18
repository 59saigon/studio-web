using NM.Studio.Domain.Models.Base;

namespace NM.Studio.Domain.Models.Services;

public class ServiceView : BaseView
{
    public string ServiceTittle { get; set; }
    
    public string? ServiceDescription { get; set; } 
    
    public Guid EventId { get; set; }
    
    public string? Type { get; set; }
    
    public double Price { get; set; }
    
    public string? Status { get; set; }
}