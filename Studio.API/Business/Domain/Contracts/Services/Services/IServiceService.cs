using Studio.API.Business.Domain.Contracts.Services.Bases;
using Studio.API.Business.Domain.CQRS.Queries.Services;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Results.Services;

namespace Studio.API.Business.Domain.Contracts.Services.Services
{
    public interface IServiceService : IBaseService
    {
        Task<MessageResults<ServiceResult>> GetAll(ServiceGetAllQuery x, CancellationToken cancellationToken = default);
    }
}
