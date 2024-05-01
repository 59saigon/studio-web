using Studio.API.Business.Domain.Contracts.Repositories.Bases;
using Studio.API.Business.Domain.Entities.Locations;

namespace Studio.API.Business.Domain.Contracts.Repositories.Locations
{
    public interface ICityRepository : IBaseRepository
    {
        Task<IList<City>> GetAllWithInclude(CancellationToken cancellationToken = default);
    }
}
