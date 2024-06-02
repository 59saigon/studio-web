using NM.Studio.Domain.Contracts.Repositories.Bases;
using NM.Studio.Domain.CQRS.Queries.Users;
using NM.Studio.Domain.Entities.Users;

namespace NM.Studio.Domain.Contracts.Repositories.Users
{
    public interface IUserRepository : IBaseRepository
    {
        Task<User> FindUsernameOrEmail(AuthQuery authQuery);
    }
}
