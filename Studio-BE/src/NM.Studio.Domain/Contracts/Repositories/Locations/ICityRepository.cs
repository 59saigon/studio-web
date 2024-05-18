using NM.Studio.Domain.Contracts.Repositories.Bases;
using NM.Studio.Domain.Entities.Locations;

namespace NM.Studio.Domain.Contracts.Repositories.Locations
{
    public interface ICityRepository : IBaseRepository
    {
        Task<IList<City>> GetAllWithInclude(CancellationToken cancellationToken = default);
    }
}
