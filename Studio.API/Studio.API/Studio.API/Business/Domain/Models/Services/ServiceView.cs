using Studio.API.Business.Domain.Models.Base;

namespace Studio.API.Business.Domain.Models.Services;

public class ServiceView : BaseView
{
    public string ServiceTittle { get; set; }
    
    public string? ServiceDescription { get; set; } 
    
    public Guid EventId { get; set; }
    
    public string? Type { get; set; }
    
    public double Price { get; set; }
    
    public string? Status { get; set; }
}