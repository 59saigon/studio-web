using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NM.Studio.Data.Context;
using NM.Studio.Data.Repositories.Base;
using NM.Studio.Domain.Contracts.Repositories.Locations;
using NM.Studio.Domain.Entities.Locations;

namespace NM.Studio.Data.Repositories.Locations
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<IList<City>> GetAllWithInclude(CancellationToken cancellationToken = default)
        {
            var queryable = base.GetQueryable();
            var results = await queryable.Where(entity => !entity.IsDeleted)
                .Include(entity => entity.Country)
                .ToListAsync();
            return results;
        }
    }
}
