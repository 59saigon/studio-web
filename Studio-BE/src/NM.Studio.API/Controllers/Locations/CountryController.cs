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

namespace NM.Studio.API.Controllers.Countrys
{
    [Authorize]
    [Route("api/country")]
    public class CountryController : BaseController
    {
        public CountryController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("get-country-list")]
        public async Task<IActionResult> GetAll([FromBody] CountryGetAllQuery countryGetAllQuery)
        {
            MessageResults<CountryResult> messageResult = await _mediator.Send(countryGetAllQuery);
            return Ok(messageResult);
        }

        // GET api/<CountryController>/5
        [HttpPost("get-by-id")]
        public async Task<IActionResult> GetById([FromBody] CountryGetByIdQuery countryGetByIdQuery)
        {
            MessageResult<CountryResult> messageResult = await _mediator.Send(countryGetByIdQuery);
            return Ok(messageResult);
        }

        // POST api/<CountryController>
        [HttpPost("create-country")]
        public async Task<IActionResult> Create([FromBody] CountryCreateCommand countryCreateCommand)
        {
            MessageView<CountryView> messageView = await _mediator.Send(countryCreateCommand);
            return Ok(messageView);
        }

        // PUT api/<CountryController>/5
        [HttpPost("update-country")]
        public async Task<IActionResult> Update([FromBody] CountryUpdateCommand countryUpdateCommand)
        {
            MessageView<CountryView> messageView = await _mediator.Send(countryUpdateCommand);
            return Ok(messageView);
        }


        // DELETE api/<CountryController>/5
        [HttpPost("delete-country")]
        public async Task<IActionResult> Delete([FromBody] CountryDeleteCommand countryDeleteCommand)
        {
            MessageView<CountryView> messageView = await _mediator.Send(countryDeleteCommand);
            return Ok(messageView);
        }
    }
}
