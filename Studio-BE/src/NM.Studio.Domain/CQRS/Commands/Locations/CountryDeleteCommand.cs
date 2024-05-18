using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models.Locations;

namespace NM.Studio.Domain.CQRS.Commands.Locations
{
    public class CountryDeleteCommand : DeleteCommand<CountryView>
    {
    }
}
