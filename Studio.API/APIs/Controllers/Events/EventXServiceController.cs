using MediatR;
using Microsoft.AspNetCore.Mvc;
using Studio.API.APIs.Controllers.Base;
using Studio.API.Business.Domain.CQRS.Commands.Events.EventXServices;
using Studio.API.Business.Domain.CQRS.Queries.Events.EventXServices;
using Studio.API.Business.Domain.Models.Events;
using Studio.API.Business.Domain.Models.Messages;
using Studio.API.Business.Domain.Results.Events;
using Studio.API.Business.Domain.Results.Messages;

namespace Studio.API.APIs.Controllers.Events
{
    [Route("api/eventXService")]
    public class EventXServiceController : BaseController
    {
        public EventXServiceController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("get-eventXService-list")]
        public async Task<IActionResult> GetAll([FromBody] EventXServiceGetAllQuery eventXServiceGetAllQuery)
        {
            MessageResults<EventXServiceResult> messageResult = await _mediator.Send(eventXServiceGetAllQuery);
            return Ok(messageResult);
        }

        // GET api/<EventXServiceController>/5
        [HttpPost("get-by-id")]
        public async Task<IActionResult> GetById([FromBody] EventXServiceGetByIdQuery eventXServiceGetByIdQuery)
        {
            MessageResult<EventXServiceResult> messageResult = await _mediator.Send(eventXServiceGetByIdQuery);
            return Ok(messageResult);
        }

        // POST api/<EventXServiceController>
        [HttpPost("create-eventXService")]
        public async Task<IActionResult> Create([FromBody] EventXServiceCreateCommand eventXServiceCreateCommand)
        {
            MessageView<EventXServiceView> messageView = await _mediator.Send(eventXServiceCreateCommand);
            return Ok(messageView);
        }

        // PUT api/<EventXServiceController>/5
        [HttpPost("update-eventXService")]
        public async Task<IActionResult> Update([FromBody] EventXServiceUpdateCommand eventXServiceUpdateCommand)
        {
            MessageView<EventXServiceView> messageView = await _mediator.Send(eventXServiceUpdateCommand);
            return Ok(messageView);
        }


        // DELETE api/<EventXServiceController>/5
        [HttpPost("delete-eventXService")]
        public async Task<IActionResult> Delete([FromBody] EventXServiceDeleteCommand eventXServiceDeleteCommand)
        {
            MessageView<EventXServiceView> messageView = await _mediator.Send(eventXServiceDeleteCommand);
            return Ok(messageView);
        }
    }
}
