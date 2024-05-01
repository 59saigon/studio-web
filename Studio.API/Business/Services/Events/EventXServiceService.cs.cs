using AutoMapper;
using Studio.API.Business.Domain.Contracts.Repositories.Events;
using Studio.API.Business.Domain.Contracts.Services.Events;
using Studio.API.Business.Domain.Contracts.UnitOfWorks;
using Studio.API.Business.Domain.CQRS.Queries.Events.EventXServices;
using Studio.API.Business.Domain.CQRS.Queries.Events.EventXServices;
using Studio.API.Business.Domain.Entities.Events;
using Studio.API.Business.Domain.Results.Events;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Utilities;
using Studio.API.Business.Services.Bases;

namespace Studio.API.Business.Services.Events
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
