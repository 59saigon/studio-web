using NM.Studio.Domain.Contracts.Repositories.Events;
using NM.Studio.Domain.Contracts.Repositories.Locations;
using NM.Studio.Domain.Contracts.Repositories.Photos;
using NM.Studio.Domain.Contracts.Repositories.Services;
using NM.Studio.Domain.Contracts.Repositories.Users;
using NM.Studio.Domain.Contracts.Repositories.Weddings;
using NM.Studio.Domain.Contracts.UnitOfWorks;
using NM.Studio.Data.Context;

namespace NM.Studio.Data.UnitOfWorks
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
