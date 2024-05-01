using Studio.API.Business.Domain.Contracts.Repositories.Bases;
using Studio.API.Business.Domain.CQRS.Queries.Services;
using Studio.API.Business.Domain.Entities.Services;

namespace Studio.API.Business.Domain.Contracts.Repositories.Services
{
    public interface IServiceRepository : IBaseRepository
    {
        Task<IList<Service>> GetAllWithInclude(ServiceGetAllQuery query, CancellationToken cancellationToken = default);
    }
}
