using MediatR;
using Studio.API.Business.Domain.CQRS.Queries.Common;
using Studio.API.Business.Domain.Results.Events;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Results.Weddings;

namespace Studio.API.Business.Domain.CQRS.Queries.Events
{
    public class EventGetAllQuery : GetQueryableQuery, IRequest<MessageResult<EventResult>>
    {
    }
}
