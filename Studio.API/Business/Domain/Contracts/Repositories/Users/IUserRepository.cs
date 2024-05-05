using Studio.API.Business.Domain.Contracts.Repositories.Bases;
using Studio.API.Business.Domain.CQRS.Queries.Users;
using Studio.API.Business.Domain.Entities.Users;

namespace Studio.API.Business.Domain.Contracts.Repositories.Users
{
    public interface IUserRepository : IBaseRepository
    {
        Task<User> FindUsernameOrEmail(AuthQuery authQuery);
    }
}
