using Studio.API.Business.Domain.Contracts.Services.Bases;
using Studio.API.Business.Domain.Results.Events;
using Studio.API.Business.Domain.Results.Messages;

namespace Studio.API.Business.Domain.Contracts.Services.Events
{
    public interface IEventService : IBaseService
    {
        Task<MessageResults<EventResult>> GetAll(CancellationToken cancellationToken = default);
    }
}
