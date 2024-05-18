using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NM.Studio.Domain.Contracts.Repositories.Bases;
using NM.Studio.Domain.Contracts.Repositories.Locations;
using NM.Studio.Domain.Entities.Locations;
using NM.Studio.Data.Context;
using NM.Studio.Data.Repositories.Base;

namespace NM.Studio.Data.Repositories.Locations
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
