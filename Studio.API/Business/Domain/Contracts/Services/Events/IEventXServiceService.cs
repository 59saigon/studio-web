using Studio.API.Business.Domain.Contracts.Services.Bases;
using Studio.API.Business.Domain.CQRS.Queries.Events.EventXServices;
using Studio.API.Business.Domain.Results.Events;
using Studio.API.Business.Domain.Results.Messages;

namespace Studio.API.Business.Domain.Contracts.Services.Events
{
    public interface IEventXServiceService : IBaseService
    {
        //Task<MessageResults<EventXServiceResult>> GetAllExceptFromIds(EventXServiceGetAllQuery x, CancellationToken cancellationToken = default);
        Task<MessageResult<EventXServiceResult>> GetByEventIdAndServiceId(EventXServiceGetByIdQuery x);
    }
}
