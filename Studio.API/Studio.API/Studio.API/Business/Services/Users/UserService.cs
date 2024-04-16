using AutoMapper;
using Studio.API.Business.Domain.Contracts.Repositories.Users;
using Studio.API.Business.Domain.Contracts.Services.Users;
using Studio.API.Business.Domain.Contracts.UnitOfWorks;
using Studio.API.Business.Domain.Entities.Users;
using Studio.API.Business.Services.Bases;

namespace Studio.API.Business.Services.Users
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _userRepository = unitOfWork.UserRepository;
        }
    }
}
