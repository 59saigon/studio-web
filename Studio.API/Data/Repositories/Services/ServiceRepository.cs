using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Studio.API.Business.Domain.Contracts.Repositories.Events;
using Studio.API.Business.Domain.Contracts.Repositories.Services;
using Studio.API.Business.Domain.CQRS.Queries.Services;
using Studio.API.Business.Domain.Entities.Events;
using Studio.API.Business.Domain.Entities.Services;
using Studio.API.Business.Domain.Entities.Services;
using Studio.API.Data.Context;
using Studio.API.Data.Repositories.Base;

namespace Studio.API.Data.Repositories.Services
{
    public class ServiceRepository : BaseRepository<Service>, IServiceRepository
    {
        public ServiceRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            
        }

        public async Task<IList<Service>> GetAllWithInclude(ServiceGetAllQuery query, CancellationToken cancellationToken = default)
        {

            var queryable = base.GetQueryable();

            // Apply base filtering: not deleted
            queryable = queryable.Where(entity => !entity.IsDeleted);

            // Additional filtering based on ServiceIds (exclude these IDs if given)
            if (query.ServiceIds != null && query.ServiceIds.Count > 0)
            {
                queryable = queryable.Where(entity => !query.ServiceIds.Contains(entity.Id));
            }

            // Include related EventXServices
            queryable = queryable.Include(entity => entity.EventXServices);

            // Execute the query asynchronously
            var results = await queryable.ToListAsync(cancellationToken);

            return results;

        }
    }
}
