using NM.Studio.Domain.Contracts.Services.Bases;
using NM.Studio.Domain.Results.Events;
using NM.Studio.Domain.Results.Messages;

namespace NM.Studio.Domain.Contracts.Services.Events
{
    public interface IEventService : IBaseService
    {
        Task<MessageResults<EventResult>> GetAll(CancellationToken cancellationToken = default);
    }
}
