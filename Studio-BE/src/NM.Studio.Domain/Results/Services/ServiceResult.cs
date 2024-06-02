using NM.Studio.Domain.Entities.Events;
using NM.Studio.Domain.Results.Bases;
using NM.Studio.Domain.Results.Events;

namespace NM.Studio.Domain.Results.Services;

public class ServiceResult : BaseResult
{
    public string ServiceTittle { get; set; }
    
    public string? ServiceDescription { get; set; } 
    
    public string? Type { get; set;  }
    
    public double Price { get; set; }
    
    public string? Status { get; set; }

    public virtual IList<EventXServiceResult> EventXServices { get; set; }
}