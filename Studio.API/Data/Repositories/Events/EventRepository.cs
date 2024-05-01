using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Studio.API.Business.Domain.Contracts.Repositories.Events;
using Studio.API.Business.Domain.Entities.Events;
using Studio.API.Data.Context;
using Studio.API.Data.Repositories.Base;

namespace Studio.API.Data.Repositories.Events
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IList<Event>> GetAllWithInclude(CancellationToken cancellationToken = default)
        {
            var queryable = base.GetQueryable();
            var results = await queryable.Where(entity => !entity.IsDeleted)
                .Include(entity => entity.EventXPhotos).ThenInclude(eventXPhoto =>  eventXPhoto.Photo)
                .Include(entity => entity.EventXServices).ThenInclude(eventXService => eventXService.Service)
                .Include(entity => entity.Location)
                .Include(entity => entity.Location.City)
                .Include(entity => entity.Location.City.Country)
                .Include(entity => entity.Wedding)
                .ToListAsync();
            return results;
        }
    }
}
