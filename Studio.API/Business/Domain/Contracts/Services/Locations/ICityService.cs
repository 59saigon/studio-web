using Studio.API.Business.Domain.Contracts.Services.Bases;
using Studio.API.Business.Domain.Entities.Locations;
using Studio.API.Business.Domain.Results.Locations;
using Studio.API.Business.Domain.Results.Messages;

namespace Studio.API.Business.Domain.Contracts.Services.Locations
{
    public interface ICityService : IBaseService
    {
        Task<MessageResults<CityResult>> GetAll(CancellationToken cancellationToken = default);
    }
}
