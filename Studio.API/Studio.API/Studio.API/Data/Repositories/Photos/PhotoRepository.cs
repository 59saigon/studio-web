using AutoMapper;
using Studio.API.Business.Domain.Contracts.Repositories.Events;
using Studio.API.Business.Domain.Contracts.Repositories.Photos;
using Studio.API.Business.Domain.Entities.Photos;
using Studio.API.Data.Context;
using Studio.API.Data.Repositories.Base;

namespace Studio.API.Data.Repositories.Photos
{
    public class PhotoRepository : BaseRepository<Photo>, IPhotoRepository
    {

        public PhotoRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
