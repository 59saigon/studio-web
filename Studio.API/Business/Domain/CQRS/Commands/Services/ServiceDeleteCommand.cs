using Studio.API.Business.Domain.CQRS.Commands.Base;
using Studio.API.Business.Domain.Models.Services;
using Studio.API.Business.Domain.Results.Services;

namespace Studio.API.Business.Domain.CQRS.Commands.Services
{
    public class ServiceDeleteCommand : DeleteCommand<ServiceView>
    {
    }
}
