using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models.Services;
using NM.Studio.Domain.Results.Services;

namespace NM.Studio.Domain.CQRS.Commands.Services
{
    public class ServiceDeleteCommand : DeleteCommand<ServiceView>
    {
    }
}
