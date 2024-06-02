using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models.Photos;

namespace NM.Studio.Domain.CQRS.Commands.Photos
{
    public class PhotoDeleteCommand : DeleteCommand<PhotoView>
    {
    }
}
