using NM.Studio.Domain.Contracts.Repositories.Bases;
using NM.Studio.Domain.CQRS.Commands.Events.EventXPhotos;
using NM.Studio.Domain.CQRS.Queries.Events.EventXPhotos;
using NM.Studio.Domain.Entities.Events;

namespace NM.Studio.Domain.Contracts.Repositories.Events
{
    public interface IEventXPhotoRepository : IBaseRepository
    {
        Task<IList<EventXPhoto>> GetAllExceptFromIds(EventXPhotoGetAllQuery eventXPhotoGetAllQuery,CancellationToken cancellationToken = default);
        Task<EventXPhoto> GetByEventIdAndPhotoId(EventXPhotoGetByIdQuery x,CancellationToken cancellationToken = default);
    }
}
