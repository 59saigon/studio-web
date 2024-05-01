using Studio.API.Business.Domain.Contracts.Repositories.Bases;
using Studio.API.Business.Domain.CQRS.Commands.Events.EventXPhotos;
using Studio.API.Business.Domain.CQRS.Queries.Events.EventXPhotos;
using Studio.API.Business.Domain.Entities.Events;

namespace Studio.API.Business.Domain.Contracts.Repositories.Events
{
    public interface IEventXPhotoRepository : IBaseRepository
    {
        Task<IList<EventXPhoto>> GetAllExceptFromIds(EventXPhotoGetAllQuery eventXPhotoGetAllQuery,CancellationToken cancellationToken = default);
        Task<EventXPhoto> GetByEventIdAndPhotoId(EventXPhotoGetByIdQuery x,CancellationToken cancellationToken = default);
    }
}
