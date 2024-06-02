using MediatR;
using NM.Studio.Domain.CQRS.Queries.Base;
using NM.Studio.Domain.Results.Weddings;

namespace NM.Studio.Domain.CQRS.Queries.Weddings
{
    public class WeddingGetByIdQuery : GetByIdQuery<WeddingResult>
    {
    }
}
