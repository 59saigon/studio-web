using AutoMapper;
using Studio.API.Business.Domain.Contracts.Repositories.Photos;
using Studio.API.Business.Domain.Contracts.Services.Photos;
using Studio.API.Business.Domain.Contracts.UnitOfWorks;
using Studio.API.Business.Domain.Entities.Photos;
using Studio.API.Business.Domain.Results.Photos;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Utilities;
using Studio.API.Business.Services.Bases;
using Studio.API.Business.Domain.CQRS.Queries.Photos;

namespace Studio.API.Business.Services.Photos
{
    public class PhotoService : BaseService<Photo>, IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;

        public PhotoService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _photoRepository = _unitOfWork.PhotoRepository;
        }
        public async Task<MessageResults<PhotoResult>> GetAll(PhotoGetAllQuery x,CancellationToken cancellationToken = default)
        {
            var photos = await _photoRepository.GetAllWithInclude(x, cancellationToken);
            // map 
            var content = _mapper.Map<IList<Photo>, List<PhotoResult>>(photos);
            var msgResults = AppMessage.GetMessageResults<PhotoResult>(content);

            return msgResults;
        }

    }
}
