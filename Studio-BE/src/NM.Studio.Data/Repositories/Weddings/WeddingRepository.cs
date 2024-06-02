using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NM.Studio.Domain.Contracts.Repositories.Weddings;
using NM.Studio.Domain.Entities.Weddings;
using NM.Studio.Data.Context;
using NM.Studio.Data.Repositories.Base;

namespace NM.Studio.Data.Repositories.Weddings
{
    public class WeddingRepository : BaseRepository<Wedding>, IWeddingRepository
    {
        public WeddingRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
