using Studio.API.Business.Domain.Contracts.Services.Bases;
using Studio.API.Business.Domain.Results.Locations;
using Studio.API.Business.Domain.Results.Messages;

namespace Studio.API.Business.Domain.Contracts.Services.Locations
{
    public interface ILocationService : IBaseService
    {
        Task<MessageResults<LocationResult>> GetAll(CancellationToken cancellationToken = default);
    }
}
