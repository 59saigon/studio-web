using AutoMapper;
using Studio.API.Business.Domain.Contracts.Repositories.Events;
using Studio.API.Business.Domain.Contracts.Services.Events;
using Studio.API.Business.Domain.Contracts.UnitOfWorks;
using Studio.API.Business.Domain.CQRS.Commands.Events.EventXPhotos;
using Studio.API.Business.Domain.CQRS.Queries.Events.EventXPhotos;
using Studio.API.Business.Domain.Entities.Events;
using Studio.API.Business.Domain.Models.Events;
using Studio.API.Business.Domain.Models.Messages;
using Studio.API.Business.Domain.Results.Events;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Utilities;
using Studio.API.Business.Services.Bases;
using System.Threading;

namespace Studio.API.Business.Services.Events
{
    public class EventXPhotoService : BaseService<EventXPhoto>, IEventXPhotoService
    {
        private readonly IEventXPhotoRepository _eventXPhotoRepository;

        public EventXPhotoService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _eventXPhotoRepository = unitOfWork.EventXPhotoRepository;
        }

        //public async Task<MessageView<EventXPhotoView>> DeleteByEventIdAndPhotoId(EventXPhotoDeleteCommand x)
        //{
        //    // if have a root id
        //    if(Guid.TryParse(x.Id.ToString(), out Guid guidOutput))
        //    {
        //        return await base.DeleteById<EventXPhotoView>(x.Id);
        //    }

        //    // create getByid
        //    EventXPhotoGetByIdQuery query = new EventXPhotoGetByIdQuery();
        //    query.PhotoId = x.PhotoId;
        //    query.EventId = x.EventId;

        //    //get to check
        //    var entity = await _eventXPhotoRepository.GetByEventIdAndPhotoId(query);
        //    if(entity == null)
        //    {
        //        //delete
        //        return null;
        //    }
        //    return await base.DeleteById<EventXPhotoView>(entity.Id);
        //}

        //public async Task<MessageResults<EventXPhotoResult>> GetAllExceptFromIds(EventXPhotoGetAllQuery x,CancellationToken cancellationToken = default)
        //{
        //    var eventXPhotos = await _eventXPhotoRepository.GetAllExceptFromIds(x,cancellationToken);
        //    // map 
        //    var content = _mapper.Map<IList<EventXPhoto>, List<EventXPhotoResult>>(eventXPhotos);
        //    var msgResults = AppMessage.GetMessageResults<EventXPhotoResult>(content);

        //    return msgResults;
        //}

        public async Task<MessageResult<EventXPhotoResult>> GetByEventIdAndPhotoId(EventXPhotoGetByIdQuery x)
        {
            var eventXPhoto = await _eventXPhotoRepository.GetByEventIdAndPhotoId(x);
            // map 
            var content = _mapper.Map<EventXPhoto, EventXPhotoResult>(eventXPhoto);
            var msgResult = AppMessage.GetMessageResult<EventXPhotoResult>(content);

            return msgResult;
        }

    }
}
