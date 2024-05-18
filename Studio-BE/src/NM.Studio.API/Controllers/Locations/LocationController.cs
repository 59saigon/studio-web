using MediatR;
using Microsoft.AspNetCore.Mvc;
using NM.Studio.API.Controllers.Base;
using NM.Studio.Domain.CQRS.Commands.Locations;
using NM.Studio.Domain.CQRS.Queries.Locations;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Domain.Models.Locations;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Results.Locations;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NM.Studio.API.Controllers.Locations
{
    [Authorize]
    [Route("api/location")]
    public class LocationController : BaseController
    {
        public LocationController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("get-location-list")]
        public async Task<IActionResult> GetAll([FromBody] LocationGetAllQuery locationGetAllQuery)
        {
            MessageResults<LocationResult> messageResult = await _mediator.Send(locationGetAllQuery);
            return Ok(messageResult);
        }

        // GET api/<LocationController>/5
        [HttpPost("get-by-id")]
        public async Task<IActionResult> GetById([FromBody] LocationGetByIdQuery locationGetByIdQuery)
        {
            MessageResult<LocationResult> messageResult = await _mediator.Send(locationGetByIdQuery);
            return Ok(messageResult);
        }

        // POST api/<LocationController>
        [HttpPost("create-location")]
        public async Task<IActionResult> Create([FromBody] LocationCreateCommand locationCreateCommand)
        {
            MessageView<LocationView> messageView = await _mediator.Send(locationCreateCommand);
            return Ok(messageView);
        }

        // PUT api/<LocationController>/5
        [HttpPost("update-location")]
        public async Task<IActionResult> Update([FromBody] LocationUpdateCommand locationUpdateCommand)
        {
            MessageView<LocationView> messageView = await _mediator.Send(locationUpdateCommand);
            return Ok(messageView);
        }


        // DELETE api/<LocationController>/5
        [HttpPost("delete-location")]
        public async Task<IActionResult> Delete([FromBody] LocationDeleteCommand locationDeleteCommand)
        {
            MessageView<LocationView> messageView = await _mediator.Send(locationDeleteCommand);
            return Ok(messageView);
        }
    }
}
