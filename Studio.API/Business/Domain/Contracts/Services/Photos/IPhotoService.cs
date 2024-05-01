using Studio.API.Business.Domain.Contracts.Services.Bases;
using Studio.API.Business.Domain.CQRS.Queries.Photos;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Results.Photos;

namespace Studio.API.Business.Domain.Contracts.Services.Photos
{
    public interface IPhotoService : IBaseService
    {
        Task<MessageResults<PhotoResult>> GetAll(PhotoGetAllQuery x, CancellationToken cancellationToken = default);
    }
}
