using AutoMapper;
using NM.Studio.Domain.Contracts.Repositories.Events;
using NM.Studio.Domain.Contracts.Services.Events;
using NM.Studio.Domain.Contracts.UnitOfWorks;
using NM.Studio.Domain.CQRS.Queries.Events.EventXServices;
using NM.Studio.Domain.Entities.Events;
using NM.Studio.Domain.Results.Events;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Utilities;
using NM.Studio.Services.Bases;

namespace NM.Studio.Services.Events
{
    public class EventXServiceService : BaseService<EventXService>, IEventXServiceService
    {
        private readonly IEventXServiceRepository _eventXServiceRepository;

        public EventXServiceService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _eventXServiceRepository = unitOfWork.EventXServiceRepository;
        }

        //public async Task<MessageResults<EventXServiceResult>> GetAllExceptFromIds(EventXServiceGetAllQuery x, CancellationToken cancellationToken = default)
        //{
        //    var eventXServices = await _eventXServiceRepository.GetAllExceptFromIds(x, cancellationToken);
        //    // map 
        //    var content = _mapper.Map<IList<EventXService>, List<EventXServiceResult>>(eventXServices);
        //    var msgResults = AppMessage.GetMessageResults<EventXServiceResult>(content);

        //    return msgResults;
        //}

        public async Task<MessageResult<EventXServiceResult>> GetByEventIdAndServiceId(EventXServiceGetByIdQuery x)
        {
            var eventXService = await _eventXServiceRepository.GetByEventIdAndServiceId(x);
            // map 
            var content = _mapper.Map<EventXService, EventXServiceResult>(eventXService);
            var msgResult = AppMessage.GetMessageResult<EventXServiceResult>(content);

            return msgResult;
        }
    }
}
