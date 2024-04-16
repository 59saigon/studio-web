using MediatR;
using Studio.API.Business.Domain.Contracts.Services.Users;
using Studio.API.Business.Domain.CQRS.Commands.Users;
using Studio.API.Business.Domain.Models.Messages;
using Studio.API.Business.Domain.Models.Users;
using Studio.API.Business.Handler.Commands.Base;

namespace Studio.API.Business.Handler.Commands.Users
{
    public class UserCommandHandler : BaseCommandHandler<UserView>,
        IRequestHandler<UserCreateCommand, MessageView<UserView>>,
        IRequestHandler<UserUpdateCommand, MessageView<UserView>>,
        IRequestHandler<UserDeleteCommand, MessageView<UserView>>
    {
        protected readonly IUserService _userService;
        public UserCommandHandler(IUserService userService) : base(userService)
        {
            _userService = userService;
        }

        public async Task<MessageView<UserView>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.CreateOrUpdate<UserView>(request);
            return msgView;
        }

        public async Task<MessageView<UserView>> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.CreateOrUpdate<UserView>(request);
            return msgView;
        }

        public async Task<MessageView<UserView>> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.DeleteById<UserView>(request.Id);
            return msgView;
        }
    }
}
