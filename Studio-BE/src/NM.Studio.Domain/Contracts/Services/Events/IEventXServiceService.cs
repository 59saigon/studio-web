using NM.Studio.Domain.Contracts.Services.Bases;
using NM.Studio.Domain.CQRS.Queries.Events.EventXServices;
using NM.Studio.Domain.Results.Events;
using NM.Studio.Domain.Results.Messages;

namespace NM.Studio.Domain.Contracts.Services.Events
{
    public interface IEventXServiceService : IBaseService
    {
        //Task<MessageResults<EventXServiceResult>> GetAllExceptFromIds(EventXServiceGetAllQuery x, CancellationToken cancellationToken = default);
        Task<MessageResult<EventXServiceResult>> GetByEventIdAndServiceId(EventXServiceGetByIdQuery x);
    }
}
