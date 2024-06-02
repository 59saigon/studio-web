using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NM.Studio.API.Controllers.Base;
using NM.Studio.Domain.CQRS.Commands.Locations;
using NM.Studio.Domain.CQRS.Queries.Locations;
using NM.Studio.Domain.Models.Locations;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Domain.Results.Locations;
using NM.Studio.Domain.Results.Messages;

namespace NM.Studio.API.Controllers.Locations
{
    [Authorize]
    [Route("api/city")]
    public class CityController : BaseController
    {
        public CityController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("get-city-list")]
        public async Task<IActionResult> GetAll([FromBody] CityGetAllQuery cityGetAllQuery)
        {
            MessageResults<CityResult> messageResult = await _mediator.Send(cityGetAllQuery);
            return Ok(messageResult);
        }

        // GET api/<CityController>/5
        [HttpPost("get-by-id")]
        public async Task<IActionResult> GetById([FromBody] CityGetByIdQuery cityGetByIdQuery)
        {
            MessageResult<CityResult> messageResult = await _mediator.Send(cityGetByIdQuery);
            return Ok(messageResult);
        }

        // POST api/<CityController>
        [HttpPost("create-city")]
        public async Task<IActionResult> Create([FromBody] CityCreateCommand cityCreateCommand)
        {
            MessageView<CityView> messageView = await _mediator.Send(cityCreateCommand);
            return Ok(messageView);
        }

        // PUT api/<CityController>/5
        [HttpPost("update-city")]
        public async Task<IActionResult> Update([FromBody] CityUpdateCommand cityUpdateCommand)
        {
            MessageView<CityView> messageView = await _mediator.Send(cityUpdateCommand);
            return Ok(messageView);
        }


        // DELETE api/<CityController>/5
        [HttpPost("delete-city")]
        public async Task<IActionResult> Delete([FromBody] CityDeleteCommand cityDeleteCommand)
        {
            MessageView<CityView> messageView = await _mediator.Send(cityDeleteCommand);
            return Ok(messageView);
        }
    }
}
