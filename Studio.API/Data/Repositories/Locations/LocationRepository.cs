using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Studio.API.Business.Domain.Contracts.Repositories.Bases;
using Studio.API.Business.Domain.Contracts.Repositories.Locations;
using Studio.API.Business.Domain.Entities.Locations;
using Studio.API.Data.Context;
using Studio.API.Data.Repositories.Base;

namespace Studio.API.Data.Repositories.Locations
{
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        public LocationRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IList<Location>> GetAllWithInclude(CancellationToken cancellationToken = default)
        {
            var queryable = base.GetQueryable();
            var results = await queryable.Where(entity => !entity.IsDeleted)
                .Include(entity => entity.City)
                .ToListAsync();
            return results;
        }
    }
}
