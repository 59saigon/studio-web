using Studio.API.Business.Domain.CQRS.Commands.Base;
using Studio.API.Business.Domain.Entities.Locations;
using Studio.API.Business.Domain.Models.Locations;

namespace Studio.API.Business.Domain.CQRS.Commands.Locations
{
    public class LocationDeleteCommand : DeleteCommand<LocationView>
    {
    }
}
