using NM.Studio.Domain.Contracts.Repositories.Bases;
using NM.Studio.Domain.Entities.Events;
using NM.Studio.Domain.Entities.Locations;

namespace NM.Studio.Domain.Contracts.Repositories.Events
{
    public interface IEventRepository : IBaseRepository
    {
        Task<IList<Event>> GetAllWithInclude(CancellationToken cancellationToken = default);
    }
}
