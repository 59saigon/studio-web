using Studio.API.Business.Domain.Contracts.Services.Bases;
using Studio.API.Business.Domain.CQRS.Queries.Events.EventXPhotos;
using Studio.API.Business.Domain.Entities.Events;
using Studio.API.Business.Domain.Results.Events;
using Studio.API.Business.Domain.Results.Messages;

namespace Studio.API.Business.Domain.Contracts.Services.Events
{
    public interface IEventXPhotoService : IBaseService
    {
        Task<MessageResults<EventXPhotoResult>> GetAllExceptFromIds(EventXPhotoGetAllQuery x,CancellationToken cancellationToken = default);
    }
}
