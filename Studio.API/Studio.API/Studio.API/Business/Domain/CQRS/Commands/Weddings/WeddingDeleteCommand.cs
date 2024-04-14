using Studio.API.Business.Domain.CQRS.Commands.Base;
using Studio.API.Business.Domain.Models.Weddings;

namespace Studio.API.Business.Domain.CQRS.Commands.Weddings
{
    public class WeddingDeleteCommand : DeleteCommand<WeddingView>
    {
    }
}
