using Studio.API.Business.Domain.Contracts.Repositories.Events;
using Studio.API.Business.Domain.Contracts.Repositories.Locations;
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
        IEvent_ImageRepository EventImageRepository { get; }
        IEventService_Repository EventServiceRepository { get; }
    }
}
