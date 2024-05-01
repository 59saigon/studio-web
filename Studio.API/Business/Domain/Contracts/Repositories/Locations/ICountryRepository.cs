using Studio.API.Business.Domain.Contracts.Repositories.Bases;
using Studio.API.Business.Domain.Entities.Locations;

namespace Studio.API.Business.Domain.Contracts.Repositories.Locations
{
    public interface ICountryRepository : IBaseRepository
    {
        Task<IList<Country>> GetAllWithInclude(CancellationToken cancellationToken = default);
    }
}
