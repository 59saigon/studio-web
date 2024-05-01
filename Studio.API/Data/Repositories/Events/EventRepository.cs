using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
            // Get the queryable base to start building the query
            var queryable = base.GetQueryable();

            // Apply basic filtering to only include non-deleted events
            queryable = queryable.Where(entity => !entity.IsDeleted);

            // Include related entities and their nested relationships
            queryable = queryable
                .Include(entity => entity.EventXPhotos) // Include EventXPhotos
                    .ThenInclude(eventXPhoto => eventXPhoto.Photo) // Include nested Photo
                .Include(entity => entity.EventXServices) // Include EventXServices
                    .ThenInclude(eventXService => eventXService.Service) // Include nested Service
                .Include(entity => entity.Location) // Include Location
                .Include(entity => entity.Location.City) // Include nested City in Location
                .Include(entity => entity.Location.City.Country) // Include nested Country in City
                .Include(entity => entity.Wedding); // Include Wedding entity

            // Asynchronously execute the query and convert the results to a list
            var events = await queryable.ToListAsync(cancellationToken);

            // Apply in-memory filtering for related collections
            foreach (var ev in events)
            {
                // Filter out deleted EventXPhotos
                ev.EventXPhotos = ev.EventXPhotos.Where(ex => !ex.IsDeleted).ToList();
            }
            return events;
        }
    }
}
