using NM.Studio.Domain.Contracts.Services.Bases;
using NM.Studio.Domain.CQRS.Commands.Events.EventXPhotos;
using NM.Studio.Domain.CQRS.Queries.Events.EventXPhotos;
using NM.Studio.Domain.Entities.Events;
using NM.Studio.Domain.Models.Base;
using NM.Studio.Domain.Models.Events;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Domain.Results.Bases;
using NM.Studio.Domain.Results.Events;
using NM.Studio.Domain.Results.Messages;

namespace NM.Studio.Domain.Contracts.Services.Events
{
    public interface IEventXPhotoService : IBaseService
    {
        //Task<MessageResults<EventXPhotoResult>> GetAllExceptFromIds(EventXPhotoGetAllQuery x, CancellationToken cancellationToken = default);
        //Task<MessageView<EventXPhotoView>> DeleteByEventIdAndPhotoId(EventXPhotoDeleteCommand x);
        Task<MessageResult<EventXPhotoResult>> GetByEventIdAndPhotoId(EventXPhotoGetByIdQuery x);
    }
}
