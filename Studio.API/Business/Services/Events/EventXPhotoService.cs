using AutoMapper;
using Studio.API.Business.Domain.Contracts.Repositories.Events;
using Studio.API.Business.Domain.Contracts.Services.Events;
using Studio.API.Business.Domain.Contracts.UnitOfWorks;
using Studio.API.Business.Domain.CQRS.Queries.Events.EventXPhotos;
using Studio.API.Business.Domain.Entities.Events;
using Studio.API.Business.Domain.Results.Events;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Utilities;
using Studio.API.Business.Services.Bases;

namespace Studio.API.Business.Services.Events
{
    public class EventXPhotoService : BaseService<EventXPhoto>, IEventXPhotoService
    {
        private readonly IEventXPhotoRepository _eventXPhotoRepository;

        public EventXPhotoService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _eventXPhotoRepository = unitOfWork.EventXPhotoRepository;
        }

        public async Task<MessageResults<EventXPhotoResult>> GetAllExceptFromIds(EventXPhotoGetAllQuery x,CancellationToken cancellationToken = default)
        {
            var eventXPhotos = await _eventXPhotoRepository.GetAllExceptFromIds(x,cancellationToken);
            // map 
            var content = _mapper.Map<IList<EventXPhoto>, List<EventXPhotoResult>>(eventXPhotos);
            var msgResults = AppMessage.GetMessageResults<EventXPhotoResult>(content);

            return msgResults;
        }
    }
}
