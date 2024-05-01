using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Studio.API.Data.Context;
using Studio.API.Data.Repositories.Base;
using Studio.API.Business.Domain.Contracts.Repositories.Locations;
using Studio.API.Business.Domain.Entities.Locations;

namespace Studio.API.Data.Repositories.Locations
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
