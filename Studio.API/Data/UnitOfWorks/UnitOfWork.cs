using Studio.API.Business.Domain.Contracts.Repositories.Events;
using Studio.API.Business.Domain.Contracts.Repositories.Locations;
using Studio.API.Business.Domain.Contracts.Repositories.Photos;
using Studio.API.Business.Domain.Contracts.Repositories.Services;
using Studio.API.Business.Domain.Contracts.Repositories.Users;
using Studio.API.Business.Domain.Contracts.Repositories.Weddings;
using Studio.API.Business.Domain.Contracts.UnitOfWorks;
using Studio.API.Data.Context;

namespace Studio.API.Data.UnitOfWorks
{
    public class UnitOfWork : BaseUnitOfWork<StudioContext>, IUnitOfWork
    {
        public UnitOfWork(StudioContext context, IServiceProvider serviceProvider) : base(context, serviceProvider)
        {
        }

        public IWeddingRepository WeddingRepository => GetRepository<IWeddingRepository>();

        public ILocationRepository LocationRepository => GetRepository<ILocationRepository>();

        public ICityRepository CityRepository => GetRepository<ICityRepository>();

        public ICountryRepository CountryRepository => GetRepository<ICountryRepository>();

        public IUserRepository UserRepository => GetRepository<IUserRepository>();

        public IEventRepository EventRepository => GetRepository<IEventRepository>();

        public IPhotoRepository PhotoRepository => GetRepository<IPhotoRepository>();

        public IServiceRepository ServiceRepository => GetRepository<IServiceRepository>();

        public IEventXPhotoRepository EventXPhotoRepository => GetRepository<IEventXPhotoRepository>();

        public IEventXServiceRepository EventXServiceRepository => GetRepository<IEventXServiceRepository>();
    }
}
