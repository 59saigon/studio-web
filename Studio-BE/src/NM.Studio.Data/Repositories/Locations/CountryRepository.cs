using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NM.Studio.Data.Context;
using NM.Studio.Data.Repositories.Base;
using NM.Studio.Domain.Entities.Locations;
using NM.Studio.Domain.Contracts.Repositories.Locations;

namespace NM.Studio.Data.Repositories.Locations
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
