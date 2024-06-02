using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NM.Studio.Domain.Contracts.Repositories.Events;
using NM.Studio.Domain.CQRS.Queries.Events.EventXServices;
using NM.Studio.Domain.Entities.Events;
using NM.Studio.Data.Context;
using NM.Studio.Data.Repositories.Base;

namespace NM.Studio.Data.Repositories.Events
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
