using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Studio.API.Business.Domain.Contracts.Repositories.Events;
using Studio.API.Business.Domain.Contracts.Repositories.Locations;
using Studio.API.Business.Domain.Contracts.Services.Events;
using Studio.API.Business.Domain.Contracts.UnitOfWorks;
using Studio.API.Business.Domain.Entities.Events;
using Studio.API.Business.Domain.Entities.Locations;
using Studio.API.Business.Domain.Results.Events;
using Studio.API.Business.Domain.Results.Locations;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Utilities;
using Studio.API.Business.Services.Bases;
using Studio.API.Data.Repositories.Locations;

namespace Studio.API.Business.Services.Events
{
    public class EventService : BaseService<Event>, IEventService
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _eventRepository = unitOfWork.EventRepository;
        }
        public async Task<MessageResults<EventResult>> GetAll(CancellationToken cancellationToken = default)
        {
            var events = await _eventRepository.GetAllWithInclude(cancellationToken);
            // map 
            var content = _mapper.Map<IList<Event>, List<EventResult>>(events);
            var msgResults = AppMessage.GetMessageResults<EventResult>(content);

            return msgResults;
        }
    }
}
