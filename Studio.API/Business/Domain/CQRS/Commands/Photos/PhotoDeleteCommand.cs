using Studio.API.Business.Domain.CQRS.Commands.Base;
using Studio.API.Business.Domain.Models.Photos;

namespace Studio.API.Business.Domain.CQRS.Commands.Photos
{
    public class PhotoDeleteCommand : DeleteCommand<PhotoView>
    {
    }
}
