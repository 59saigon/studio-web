using Studio.API.Business.Domain.Contracts.Repositories.Events;
using Studio.API.Business.Domain.Contracts.Repositories.Locations;
using Studio.API.Business.Domain.Contracts.Repositories.Photos;
using Studio.API.Business.Domain.Contracts.Repositories.Services;
using Studio.API.Business.Domain.Contracts.Repositories.Users;
using Studio.API.Business.Domain.Contracts.Repositories.Weddings;

namespace Studio.API.Business.Domain.Contracts.UnitOfWorks
{
    public interface IUnitOfWork : IBaseUnitOfWork
    {
        IWeddingRepository WeddingRepository { get; }
        ILocationRepository LocationRepository { get; }
        ICityRepository CityRepository { get; }
        ICountryRepository CountryRepository { get; }
        IUserRepository UserRepository { get; }
        IEventRepository EventRepository { get; }
        IPhotoRepository PhotoRepository { get; }
        IServiceRepository ServiceRepository { get; }
    }
}
