using NM.Studio.Domain.Contracts.Repositories.Bases;
using NM.Studio.Domain.Entities.Locations;

namespace NM.Studio.Domain.Contracts.Repositories.Locations
{
    public interface ILocationRepository : IBaseRepository
    {
        Task<IList<Location>> GetAllWithInclude(CancellationToken cancellationToken = default);
    }
}
