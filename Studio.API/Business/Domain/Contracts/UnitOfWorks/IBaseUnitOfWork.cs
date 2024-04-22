using Studio.API.Business.Domain.Contracts.Repositories.Bases;
using Studio.API.Business.Domain.Entities.Bases;

namespace Studio.API.Business.Domain.Contracts.UnitOfWorks
{
    public interface IBaseUnitOfWork : IDisposable
    {
        IBaseRepository<TEntity> GetRepositoryByEntity<TEntity>() where TEntity: BaseEntity;  

        TRepository GetRepository<TRepository>() where TRepository: IBaseRepository;

        Task<bool> SaveChanges(CancellationToken cancellationToken = default);
    }
}
