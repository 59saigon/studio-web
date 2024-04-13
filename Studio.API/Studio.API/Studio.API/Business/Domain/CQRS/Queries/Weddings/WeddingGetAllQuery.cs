using MediatR;
using Studio.API.Business.Domain.CQRS.Queries.Base;
using Studio.API.Business.Domain.CQRS.Queries.Common;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Results.Weddings;

namespace Studio.API.Business.Domain.CQRS.Queries.Weddings
{
    public class WeddingGetAllQuery : GetQueryableQuery, IRequest<MessageResults<WeddingResult>>
    {
    }
}
