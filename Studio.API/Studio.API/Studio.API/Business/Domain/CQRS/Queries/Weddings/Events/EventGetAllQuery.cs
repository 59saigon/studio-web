using MediatR;
using Studio.API.Business.Domain.CQRS.Queries.Common;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Results.Weddings;
using Studio.API.Business.Domain.Results.Weddings.Events;

namespace Studio.API.Business.Domain.CQRS.Queries.Weddings.Events
{
    public class EventGetAllQuery : GetQueryableQuery, IRequest<MessageResult<EventResult>>
    {
    }
}
