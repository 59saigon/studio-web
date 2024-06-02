using NM.Studio.Domain.Contracts.Services.Bases;
using NM.Studio.Domain.CQRS.Queries.Photos;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Results.Photos;

namespace NM.Studio.Domain.Contracts.Services.Photos
{
    public interface IPhotoService : IBaseService
    {
        Task<MessageResults<PhotoResult>> GetAll(PhotoGetAllQuery x, CancellationToken cancellationToken = default);
    }
}
