using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NM.Studio.Domain.Contracts.Repositories.Events;
using NM.Studio.Domain.CQRS.Queries.Events.EventXPhotos;
using NM.Studio.Domain.Entities.Events;
using NM.Studio.Data.Context;
using NM.Studio.Data.Repositories.Base;

namespace NM.Studio.Data.Repositories.Events
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
