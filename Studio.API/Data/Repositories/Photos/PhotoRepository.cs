using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Studio.API.Business.Domain.Contracts.Repositories.Events;
using Studio.API.Business.Domain.Contracts.Repositories.Photos;
using Studio.API.Business.Domain.CQRS.Queries.Photos;
using Studio.API.Business.Domain.Entities.Photos;
using Studio.API.Data.Context;
using Studio.API.Data.Repositories.Base;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Studio.API.Data.Repositories.Photos
{
    public class PhotoRepository : BaseRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IList<Photo>> GetAllWithInclude(PhotoGetAllQuery query, CancellationToken cancellationToken = default)
        {

            var queryable = base.GetQueryable();

            // Apply base filtering: not deleted
            queryable = queryable.Where(entity => !entity.IsDeleted);

            // Additional filtering based on PhotoIds (exclude these IDs if given)
            if (query.PhotoIds != null && query.PhotoIds.Count > 0)
            {
                queryable = queryable.Where(entity => !query.PhotoIds.Contains(entity.Id));
            }

            // Include related EventXPhotos
            queryable = queryable.Include(entity => entity.EventXPhotos);

            // Execute the query asynchronously
            var results = await queryable.ToListAsync(cancellationToken);

            return results;

        }
    }
}
