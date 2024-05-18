using AutoMapper;
using NM.Studio.Domain.Contracts.Repositories.Events;
using NM.Studio.Domain.Contracts.Services.Events;
using NM.Studio.Domain.Contracts.UnitOfWorks;
using NM.Studio.Domain.CQRS.Commands.Events.EventXPhotos;
using NM.Studio.Domain.CQRS.Queries.Events.EventXPhotos;
using NM.Studio.Domain.Entities.Events;
using NM.Studio.Domain.Models.Events;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Domain.Results.Events;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Utilities;
using NM.Studio.Services.Bases;
using System.Threading;

namespace NM.Studio.Services.Events
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
