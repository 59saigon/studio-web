using MediatR;
using Studio.API.Business.Domain.CQRS.Queries.Base;
using Studio.API.Business.Domain.Results.Weddings;

namespace Studio.API.Business.Domain.CQRS.Queries.Weddings
{
    public class WeddingGetAllQuery : GetAllQuery<WeddingResult>
    {
    }
}
