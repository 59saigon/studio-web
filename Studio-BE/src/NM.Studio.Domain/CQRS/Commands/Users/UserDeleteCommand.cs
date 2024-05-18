using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models.Users;

namespace NM.Studio.Domain.CQRS.Commands.Users
{
    public class UserDeleteCommand : DeleteCommand<UserView>
    {
    }
}
