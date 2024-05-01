using Studio.API.Business.Domain.CQRS.Commands.Base;
using Studio.API.Business.Domain.Models.Photos;

namespace Studio.API.Business.Domain.CQRS.Commands.Photos
{
    public class PhotoUpdateCommand : UpdateCommand<PhotoView>
    {
        public string? PhotoName { get; set; }

        public string Url { get; set; }

        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
