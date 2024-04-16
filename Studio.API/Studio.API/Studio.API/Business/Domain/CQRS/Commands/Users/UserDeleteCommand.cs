using Studio.API.Business.Domain.CQRS.Commands.Base;
using Studio.API.Business.Domain.Models.Users;

namespace Studio.API.Business.Domain.CQRS.Commands.Users
{
    public class UserDeleteCommand : DeleteCommand<UserView>
    {
    }
}
