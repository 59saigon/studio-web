using Studio.API.Business.Domain.Contracts.Services.Bases;
using Studio.API.Business.Domain.CQRS.Commands.Users;
using Studio.API.Business.Domain.CQRS.Queries.Users;
using Studio.API.Business.Domain.Models.Messages;
using Studio.API.Business.Domain.Models.Users;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Results.Users;

namespace Studio.API.Business.Domain.Contracts.Services.Users
{
    public interface IUserService : IBaseService
    {
        Task<MessageLoginResult<UserResult>> Login(AuthQuery x, CancellationToken cancellationToken = default);
        Task<MessageView<UserView>> Register(UserCreateCommand x, CancellationToken cancellationToken = default);
    }
}
