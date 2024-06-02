using NM.Studio.Domain.CQRS.Queries.Base;
using NM.Studio.Domain.Results.Services;

namespace NM.Studio.Domain.CQRS.Queries.Services
{
    public class ServiceGetAllQuery : GetAllQuery<ServiceResult>
    {
        public List<Guid>? ServiceIds { get; set; }
    }
}
