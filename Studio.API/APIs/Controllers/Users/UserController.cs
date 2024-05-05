using MediatR;
using Microsoft.AspNetCore.Mvc;
using Studio.API.APIs.Controllers.Base;
using Studio.API.Business.Domain.CQRS.Commands.Users;
using Studio.API.Business.Domain.CQRS.Queries.Users;
using Studio.API.Business.Domain.Models.Messages;
using Studio.API.Business.Domain.Models.Users;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Results.Users;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Studio.API.APIs.Controllers.Users
{
    [Route("api/user")]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("get-user-list")]
        public async Task<IActionResult> GetAll([FromBody] UserGetAllQuery userGetAllQuery)
        {
            MessageResults<UserResult> messageResult = await _mediator.Send(userGetAllQuery);
            return Ok(messageResult);
        }

        // GET api/<UserController>/5
        [HttpPost("get-by-id")]
        public async Task<IActionResult> GetById([FromBody] UserGetByIdQuery userGetByIdQuery)
        {
            MessageResult<UserResult> messageResult = await _mediator.Send(userGetByIdQuery);
            return Ok(messageResult);
        }

        // PUT api/<UserController>/5
        [HttpPost("update-user")]
        public async Task<IActionResult> Update([FromBody] UserUpdateCommand userUpdateCommand)
        {
            MessageView<UserView> messageView = await _mediator.Send(userUpdateCommand);
            return Ok(messageView);
        }

        // DELETE api/<UserController>/5
        [HttpPost("delete-user")]
        public async Task<IActionResult> Delete([FromBody] UserDeleteCommand userDeleteCommand)
        {
            MessageView<UserView> messageView = await _mediator.Send(userDeleteCommand);
            return Ok(messageView);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthQuery authQuery)
        {
            MessageResult<AuthResult> messageResult = await _mediator.Send(authQuery);
            return Ok(messageResult);
        }

        // POST api/<AuthController>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserCreateCommand userCreateCommand)
        {
            MessageView<UserView> messageView = await _mediator.Send(userCreateCommand);
            return Ok(messageView);
        }
    }
}
