using Studio.API.Business.Domain.CQRS.Queries.Base;
using Studio.API.Business.Domain.Results.Photos;

namespace Studio.API.Business.Domain.CQRS.Queries.Photos
{
    public class PhotoGetAllQuery : GetAllQuery<PhotoResult>
    {
        public List<Guid> PhotoIds { get; set; } = new List<Guid>();
    }
}
