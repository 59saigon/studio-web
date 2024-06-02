using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models.Events;

namespace NM.Studio.Domain.CQRS.Commands.Events
{
    public class EventDeleteCommand : DeleteCommand<EventView>
    {
    }
}
