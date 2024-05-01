using Studio.API.Business.Domain.Contracts.Repositories.Bases;
using Studio.API.Business.Domain.CQRS.Queries.Events.EventXPhotos;
using Studio.API.Business.Domain.CQRS.Queries.Events.EventXServices;
using Studio.API.Business.Domain.Entities.Events;

namespace Studio.API.Business.Domain.Contracts.Repositories.Events
{
    public interface IEventXServiceRepository : IBaseRepository
    {
        Task<IList<EventXService>> GetAllExceptFromIds(EventXServiceGetAllQuery x, CancellationToken cancellationToken = default);
        Task<EventXService> GetByEventIdAndServiceId(EventXServiceGetByIdQuery x, CancellationToken cancellationToken = default);

    }
}
