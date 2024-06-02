using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NM.Studio.Domain.Contracts.Repositories.Events;
using NM.Studio.Domain.Contracts.Repositories.Locations;
using NM.Studio.Domain.Contracts.Services.Events;
using NM.Studio.Domain.Contracts.UnitOfWorks;
using NM.Studio.Domain.Entities.Events;
using NM.Studio.Domain.Entities.Locations;
using NM.Studio.Domain.Results.Events;
using NM.Studio.Domain.Results.Locations;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Utilities;
using NM.Studio.Services.Bases;

namespace NM.Studio.Services.Events
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
