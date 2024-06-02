using NM.Studio.Domain.Contracts.Services.Bases;
using NM.Studio.Domain.CQRS.Queries.Services;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Results.Services;

namespace NM.Studio.Domain.Contracts.Services.Services
{
    public interface IServiceService : IBaseService
    {
        Task<MessageResults<ServiceResult>> GetAll(ServiceGetAllQuery x, CancellationToken cancellationToken = default);
    }
}
