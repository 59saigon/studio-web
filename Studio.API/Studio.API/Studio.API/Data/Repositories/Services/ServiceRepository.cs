using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Studio.API.Business.Domain.Contracts.Repositories.Events;
using Studio.API.Business.Domain.Entities.Events;
using Studio.API.Data.Context;
using Studio.API.Data.Repositories.Base;

namespace Studio.API.Data.Repositories.Services
{
    public class ServiceRepository : BaseRepository<Event_Service>, IEventService_Repository
    {
        public ServiceRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
