using Studio.API.Business.Domain.Contracts.Services.Bases;
using Studio.API.Business.Domain.Results.Locations;
using Studio.API.Business.Domain.Results.Messages;
namespace Studio.API.Business.Domain.Contracts.Services.Locations
{
    public interface ICountryService : IBaseService
    {
        Task<MessageResults<CountryResult>> GetAll(CancellationToken cancellationToken = default);
    }
}
