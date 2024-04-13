using Studio.API.Business.Domain.Contracts.Services.Bases;
using Studio.API.Business.Domain.CQRS.Queries.Weddings;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Results.Weddings;

namespace Studio.API.Business.Domain.Contracts.Services.Weddings
{
    public interface IWeddingService : IBaseService
    {
        Task<MessageResults<WeddingResult>> GetAll(WeddingGetAllQuery weddingGetAllQuery, CancellationToken cancellationToken = default);
    }
}
