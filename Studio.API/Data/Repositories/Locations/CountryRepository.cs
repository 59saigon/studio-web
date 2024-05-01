using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Studio.API.Data.Context;
using Studio.API.Data.Repositories.Base;
using Studio.API.Business.Domain.Entities.Locations;
using Studio.API.Business.Domain.Contracts.Repositories.Locations;

namespace Studio.API.Data.Repositories.Locations
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<IList<Country>> GetAllWithInclude(CancellationToken cancellationToken = default)
        {
            var queryable = base.GetQueryable();
            var results = await queryable.Where(entity => !entity.IsDeleted)
                .Include(entity => entity.Cities)
                .ToListAsync();
            return results;
        }
    }
}
