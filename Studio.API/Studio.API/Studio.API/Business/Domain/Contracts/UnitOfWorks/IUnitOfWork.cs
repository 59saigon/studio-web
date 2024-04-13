using Studio.API.Business.Domain.Contracts.Repositories.Weddings;

namespace Studio.API.Business.Domain.Contracts.UnitOfWorks
{
    public interface IUnitOfWork : IBaseUnitOfWork
    {
        IWeddingRepository WeddingRepository { get; }
    }
}
