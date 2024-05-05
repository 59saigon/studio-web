using MediatR;
using Studio.API.Business.Domain.CQRS.Queries.Base;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Results.Users;

namespace Studio.API.Business.Domain.CQRS.Queries.Users
{
    public class AuthQuery : BaseQuery, IRequest<MessageResult<AuthResult>>
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
