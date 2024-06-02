using NM.Studio.Domain.Contracts.Services.Bases;
using NM.Studio.Domain.Results.Locations;
using NM.Studio.Domain.Results.Messages;

namespace NM.Studio.Domain.Contracts.Services.Locations
{
    public interface ILocationService : IBaseService
    {
        Task<MessageResults<LocationResult>> GetAll(CancellationToken cancellationToken = default);
    }
}
