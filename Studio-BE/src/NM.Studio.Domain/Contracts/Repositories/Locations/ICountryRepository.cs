using NM.Studio.Domain.Contracts.Repositories.Bases;
using NM.Studio.Domain.Entities.Locations;

namespace NM.Studio.Domain.Contracts.Repositories.Locations
{
    public interface ICountryRepository : IBaseRepository
    {
        Task<IList<Country>> GetAllWithInclude(CancellationToken cancellationToken = default);
    }
}
