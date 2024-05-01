using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Studio.API.Business.Domain.Contracts.Repositories.Events;
using Studio.API.Business.Domain.CQRS.Commands.Events.EventXPhotos;
using Studio.API.Business.Domain.CQRS.Queries.Events.EventXPhotos;
using Studio.API.Business.Domain.Entities.Events;
using Studio.API.Data.Context;
using Studio.API.Data.Repositories.Base;

namespace Studio.API.Data.Repositories.Events
{
    public class EventXPhotoRepository : BaseRepository<EventXPhoto>, IEventXPhotoRepository
    {
        public EventXPhotoRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IList<EventXPhoto>> GetAllExceptFromIds(EventXPhotoGetAllQuery x,CancellationToken cancellationToken = default)
        {
            // get from eventId - assigned eventId with photoId (not except)
            var queryable = base.GetQueryable();
            var results = await queryable.Where(entity => !entity.IsDeleted 
            && entity.EventId == x.EventId) 
                .Include(entity => entity.Event)
                .Include(entity => entity.Photo)
                .ToListAsync();
            return results;
        }

        public async Task<EventXPhoto> GetByEventIdAndPhotoId(EventXPhotoGetByIdQuery x, CancellationToken cancellationToken = default)
        {
            var queryable = base.GetQueryable(entity => entity.EventId == x.EventId
            && entity.PhotoId == x.PhotoId);
            var result = await queryable.Where(entity => !entity.IsDeleted)
                .Include(entity => entity.Event)
                .Include(entity => entity.Photo)
                .SingleOrDefaultAsync();
            return result;
        }
    }
}
