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

        public async Task<IList<EventXService>> GetAllExceptFromIds(EventXServiceGetAllQuery x, CancellationToken cancellationToken = default)
        {
            var queryable = base.GetQueryable();
            var results = await queryable.Where(entity => !entity.IsDeleted
            && entity.EventId == x.EventId && entity.ServiceId != x.ServiceId)
                .Include(entity => entity.Event)
                .Include(entity => entity.Service)
                .ToListAsync();
            return results;
        }

    }
}
