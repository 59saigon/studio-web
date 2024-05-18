using NM.Studio.Domain.Contracts.Repositories.Bases;
using NM.Studio.Domain.CQRS.Queries.Events.EventXPhotos;
using NM.Studio.Domain.CQRS.Queries.Events.EventXServices;
using NM.Studio.Domain.Entities.Events;

namespace NM.Studio.Domain.Contracts.Repositories.Events
{
    public interface IEventXServiceRepository : IBaseRepository
    {
        Task<IList<EventXService>> GetAllExceptFromIds(EventXServiceGetAllQuery x, CancellationToken cancellationToken = default);
        Task<EventXService> GetByEventIdAndServiceId(EventXServiceGetByIdQuery x, CancellationToken cancellationToken = default);

    }
}
