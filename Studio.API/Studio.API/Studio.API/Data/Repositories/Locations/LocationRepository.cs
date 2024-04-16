using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    }
}
