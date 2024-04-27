using Studio.API.Business.Domain.Entities.Events;
using Studio.API.Business.Domain.Results.Bases;
using Studio.API.Business.Domain.Results.Events;

namespace Studio.API.Business.Domain.Results.Services;

public class ServiceResult : BaseResult
{
    public string ServiceTittle { get; set; }
    
    public string? ServiceDescription { get; set; } 
    
    public string? Type { get; set;  }
    
    public double Price { get; set; }
    
    public string? Status { get; set; }

    public virtual IList<EventXServiceResult> EventXServices { get; set; }
}