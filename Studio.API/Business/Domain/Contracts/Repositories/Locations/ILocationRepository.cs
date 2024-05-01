using Studio.API.Business.Domain.Contracts.Repositories.Bases;
using Studio.API.Business.Domain.Entities.Locations;

namespace Studio.API.Business.Domain.Contracts.Repositories.Locations
{
    public interface ILocationRepository : IBaseRepository
    {
        Task<IList<Location>> GetAllWithInclude(CancellationToken cancellationToken = default);
    }
}
