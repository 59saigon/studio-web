using NM.Studio.Domain.Contracts.Repositories.Events;
using NM.Studio.Domain.Contracts.Repositories.Locations;
using NM.Studio.Domain.Contracts.Repositories.Photos;
using NM.Studio.Domain.Contracts.Repositories.Services;
using NM.Studio.Domain.Contracts.Repositories.Users;
using NM.Studio.Domain.Contracts.Repositories.Weddings;

namespace NM.Studio.Domain.Contracts.UnitOfWorks
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
        IEventXPhotoRepository EventXPhotoRepository { get; }
        IEventXServiceRepository EventXServiceRepository { get; }
    }
}
