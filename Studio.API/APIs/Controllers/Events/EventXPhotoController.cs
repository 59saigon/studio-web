using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Studio.API.APIs.Controllers.Base;
using Studio.API.Business.Domain.CQRS.Commands.Events.EventXPhotos;
using Studio.API.Business.Domain.CQRS.Queries.Events.EventXPhotos;
using Studio.API.Business.Domain.Models.Events;
using Studio.API.Business.Domain.Models.Messages;
using Studio.API.Business.Domain.Results.Events;
using Studio.API.Business.Domain.Results.Messages;

namespace Studio.API.APIs.Controllers.Events
{
    [Route("api/eventXPhoto")]
    [Authorize]
    public class EventXPhotoController : BaseController
    {
        public EventXPhotoController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("get-eventXPhoto-list")]
        public async Task<IActionResult> GetAll([FromBody] EventXPhotoGetAllQuery eventXPhotoGetAllQuery)
        {
            MessageResults<EventXPhotoResult> messageResult = await _mediator.Send(eventXPhotoGetAllQuery);
            return Ok(messageResult);
        }

        // GET api/<EventXPhotoController>/5
        [HttpPost("get-by-id")]
        public async Task<IActionResult> GetById([FromBody] EventXPhotoGetByIdQuery eventXPhotoGetByIdQuery)
        {
            MessageResult<EventXPhotoResult> messageResult = await _mediator.Send(eventXPhotoGetByIdQuery);
            return Ok(messageResult);
        }

        // POST api/<EventXPhotoController>
        [HttpPost("create-eventXPhoto")]
        public async Task<IActionResult> Create([FromBody] EventXPhotoCreateCommand eventXPhotoCreateCommand)
        {
            MessageView<EventXPhotoView> messageView = await _mediator.Send(eventXPhotoCreateCommand);
            return Ok(messageView);
        }

        // PUT api/<EventXPhotoController>/5
        [HttpPost("update-eventXPhoto")]
        public async Task<IActionResult> Update([FromBody] EventXPhotoUpdateCommand eventXPhotoUpdateCommand)
        {
            MessageView<EventXPhotoView> messageView = await _mediator.Send(eventXPhotoUpdateCommand);
            return Ok(messageView);
        }


        // DELETE api/<EventXPhotoController>/5
        [HttpPost("delete-eventXPhoto")]
        public async Task<IActionResult> Delete([FromBody] EventXPhotoDeleteCommand eventXPhotoDeleteCommand)
        {
            MessageView<EventXPhotoView> messageView = await _mediator.Send(eventXPhotoDeleteCommand);
            return Ok(messageView);
        }
    }
}
