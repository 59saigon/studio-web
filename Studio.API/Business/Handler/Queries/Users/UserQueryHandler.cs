using MediatR;
using Studio.API.Business.Domain.Contracts.Services.Users;
using Studio.API.Business.Domain.CQRS.Queries.Users;
using Studio.API.Business.Domain.Models.Users;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Results.Users;
using Studio.API.Business.Handler.Queries.Base;

namespace Studio.API.Business.Handler.Queries.Users
{
    public class UserQueryHandler : BaseQueryHandler<UserView>,
        IRequestHandler<UserGetAllQuery, MessageResults<UserResult>>,
        IRequestHandler<UserGetByIdQuery, MessageResult<UserResult>>,
        IRequestHandler<AuthQuery, MessageResult<AuthResult>>

    {
        protected readonly IUserService _userService;
        public UserQueryHandler(IUserService userService) : base(userService)
        {
            _userService = userService;
        }

        public async Task<MessageResults<UserResult>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetAll<UserResult>();
        }

        public async Task<MessageResult<UserResult>> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetById<UserResult>(request.Id);
        }

        public async Task<MessageResult<AuthResult>> Handle(AuthQuery request, CancellationToken cancellationToken)
        {
            var msgView = await _userService.Login(request, cancellationToken);
            return msgView;
        }
    }
}
