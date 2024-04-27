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
            var queryable = _baseRepository.GetQueryable();
            var results = await queryable.Where(entity => !entity.IsDeleted)
                .Include(entity => entity.EventXPhotos)
                .Include(entity => entity.EventXServices)
                .Include(entity => entity.Location)
                .Include(entity => entity.Wedding)
                .ToListAsync();

            // map 
            var content = _mapper.Map<IList<Event>, List<EventResult>>(results);
            var msgResults = AppMessage.GetMessageResults<EventResult>(content);

            return msgResults;
        }
    }
}
