using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Studio.API.Business.Domain.Contracts.Repositories.Weddings;
using Studio.API.Business.Domain.Entities.Weddings;
using Studio.API.Data.Context;
using Studio.API.Data.Repositories.Base;

namespace Studio.API.Data.Repositories.Weddings
{
    public class WeddingRepository : BaseRepository<Wedding>, IWeddingRepository
    {
        public WeddingRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
