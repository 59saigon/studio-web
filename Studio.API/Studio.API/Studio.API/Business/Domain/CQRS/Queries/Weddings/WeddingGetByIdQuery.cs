using MediatR;
using Studio.API.Business.Domain.CQRS.Queries.Common;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Results.Weddings;

namespace Studio.API.Business.Domain.CQRS.Queries.Weddings
{
    public class WeddingGetByIdQuery : GetQueryableQuery, IRequest<MessageResult<WeddingResult>>
    {
        public Guid Id { get; set; }
    }
}
