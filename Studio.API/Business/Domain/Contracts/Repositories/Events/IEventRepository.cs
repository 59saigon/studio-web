using Studio.API.Business.Domain.Contracts.Repositories.Bases;
using Studio.API.Business.Domain.Entities.Events;
using Studio.API.Business.Domain.Entities.Locations;

namespace Studio.API.Business.Domain.Contracts.Repositories.Events
{
    public interface IEventRepository : IBaseRepository
    {
        Task<IList<Event>> GetAllWithInclude(CancellationToken cancellationToken = default);
    }
}
