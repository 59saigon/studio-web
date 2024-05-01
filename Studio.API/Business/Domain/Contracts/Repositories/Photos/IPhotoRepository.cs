using Studio.API.Business.Domain.Contracts.Repositories.Bases;
using Studio.API.Business.Domain.CQRS.Queries.Photos;
using Studio.API.Business.Domain.Entities.Locations;
using Studio.API.Business.Domain.Entities.Photos;

namespace Studio.API.Business.Domain.Contracts.Repositories.Photos
{
    public interface IPhotoRepository : IBaseRepository
    {
        Task<IList<Photo>> GetAllWithInclude(PhotoGetAllQuery x,CancellationToken cancellationToken = default);
    }
}
