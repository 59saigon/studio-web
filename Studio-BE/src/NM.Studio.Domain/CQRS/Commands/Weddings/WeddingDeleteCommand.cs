using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models.Weddings;

namespace NM.Studio.Domain.CQRS.Commands.Weddings
{
    public class WeddingDeleteCommand : DeleteCommand<WeddingView>
    {
    }
}
