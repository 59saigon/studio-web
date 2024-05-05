using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Studio.API.Business.Domain.Contracts.Repositories.Events;
using Studio.API.Business.Domain.Contracts.Repositories.Users;
using Studio.API.Business.Domain.CQRS.Queries.Users;
using Studio.API.Business.Domain.Entities.Events;
using Studio.API.Business.Domain.Entities.Users;
using Studio.API.Data.Context;
using Studio.API.Data.Repositories.Base;

namespace Studio.API.Data.Repositories.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(StudioContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<User> FindUsernameOrEmail(AuthQuery authQuery)
        {
            var queryable = base.GetQueryable();

            // Apply base filtering: not deleted
            queryable = queryable.Where(entity => !entity.IsDeleted);

            // Check username or email
            if (!string.IsNullOrEmpty(authQuery.UserNameOrEmail))
            {
                queryable = queryable.Where(entity => authQuery.UserNameOrEmail.ToLower() == entity.Username.ToLower()
                                            || authQuery.UserNameOrEmail.ToLower() == entity.Email.ToLower()
                );
            }

            // Include related EventXPhotos
            queryable = queryable.Include(entity => entity.Role);

            // Execute the query asynchronously
            var result = await queryable.SingleOrDefaultAsync();

            return result;
        }
    }
}
