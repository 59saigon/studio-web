using NM.Studio.Domain.Contracts.Services.Bases;
using NM.Studio.Domain.Entities.Locations;
using NM.Studio.Domain.Results.Locations;
using NM.Studio.Domain.Results.Messages;

namespace NM.Studio.Domain.Contracts.Services.Locations
{
    public interface ICityService : IBaseService
    {
        Task<MessageResults<CityResult>> GetAll(CancellationToken cancellationToken = default);
    }
}
