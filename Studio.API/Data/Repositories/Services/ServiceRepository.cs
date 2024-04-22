using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Studio.API.Business.Domain.Contracts.Repositories.Events;
using Studio.API.Business.Domain.Contracts.Repositories.Services;
using Studio.API.Business.Domain.Entities.Events;
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
    }
}
