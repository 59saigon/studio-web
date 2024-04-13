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
    }
}
