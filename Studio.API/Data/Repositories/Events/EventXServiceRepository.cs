using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Studio.API.Business.Domain.Contracts.Repositories.Events;
using Studio.API.Business.Domain.CQRS.Queries.Events.EventXServices;
using Studio.API.Business.Domain.Entities.Events;
using Studio.API.Data.Context;
using Studio.API.Data.Repositories.Base;

namespace Studio.API.Data.Repositories.Events
{
    public class EventXServiceRepository : BaseRepository<EventXService>, IEventXServiceRepository
    {
        public EventXServiceRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IList<EventXService>> GetAllExceptFromIds(EventXServiceGetAllQuery query, CancellationToken cancellationToken = default)
        {
            var queryable = base.GetQueryable();

            // Apply filtering criteria to exclude deleted records, and select only those with matching EventId but different ServiceId
            var results = await queryable
                .Where(entity => !entity.IsDeleted && entity.EventId == query.EventId && entity.ServiceId != query.ServiceId)
                .Include(entity => entity.Event)  // Include related Event object
                .Include(entity => entity.Service)  // Include related Service object
                .ToListAsync(cancellationToken);  // Pass CancellationToken for responsiveness

            return results;
        }

        public async Task<EventXService> GetByEventIdAndServiceId(EventXServiceGetByIdQuery query, CancellationToken cancellationToken = default)
        {
            var queryable = base.GetQueryable();

            // Apply filtering to find a specific record by EventId and ServiceId
            var result = await queryable
                .Where(entity => !entity.IsDeleted && entity.EventId == query.EventId && entity.ServiceId == query.ServiceId)
                .Include(entity => entity.Event)  // Include related Event object
                .Include(entity => entity.Service)  // Include related Service object
                .SingleOrDefaultAsync(cancellationToken);  // Expecting a single or null result, use SingleOrDefaultAsync

            return result;
        }
    }
}
