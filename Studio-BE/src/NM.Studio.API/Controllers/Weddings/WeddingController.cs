using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NM.Studio.API.Controllers.Base;
using NM.Studio.Domain.CQRS.Commands.Weddings;
using NM.Studio.Domain.CQRS.Queries.Weddings;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Domain.Models.Weddings;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Results.Weddings;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NM.Studio.API.Controllers.Weddings
{
    [Authorize]
    [Route("api/wedding")]
    public class WeddingController : BaseController
    {
        public WeddingController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("get-wedding-list")]
        public async Task<IActionResult> GetAll([FromBody] WeddingGetAllQuery weddingGetAllQuery)
        {   
            MessageResults<WeddingResult> messageResult = await _mediator.Send(weddingGetAllQuery);
            return Ok(messageResult);
        }

        // GET api/<WeddingController>/5
        [HttpPost("get-by-id")]
        public async Task<IActionResult> GetById([FromBody] WeddingGetByIdQuery weddingGetByIdQuery)
        {
            MessageResult<WeddingResult> messageResult = await _mediator.Send(weddingGetByIdQuery);
            return Ok(messageResult);
        }

        // POST api/<WeddingController>
        [HttpPost("create-wedding")]
        public async Task<IActionResult> Create([FromBody] WeddingCreateCommand weddingCreateCommand)
        {
            MessageView<WeddingView> messageView = await _mediator.Send(weddingCreateCommand);
            return Ok(messageView);
        }

        // PUT api/<WeddingController>/5
        [HttpPost("update-wedding")]
        public async Task<IActionResult> Update([FromBody] WeddingUpdateCommand weddingUpdateCommand)
        {
            MessageView<WeddingView> messageView = await _mediator.Send(weddingUpdateCommand);
            return Ok(messageView);
        }


        // DELETE api/<WeddingController>/5
        [HttpPost("delete-wedding")]
        public async Task<IActionResult> Delete([FromBody] WeddingDeleteCommand weddingDeleteCommand)
        {
            MessageView<WeddingView> messageView = await _mediator.Send(weddingDeleteCommand);
            return Ok(messageView);
        }
    }
}
