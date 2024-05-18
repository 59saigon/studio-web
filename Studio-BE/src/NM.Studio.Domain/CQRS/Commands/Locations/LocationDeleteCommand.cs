using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Entities.Locations;
using NM.Studio.Domain.Models.Locations;

namespace NM.Studio.Domain.CQRS.Commands.Locations
{
    public class LocationDeleteCommand : DeleteCommand<LocationView>
    {
    }
}
