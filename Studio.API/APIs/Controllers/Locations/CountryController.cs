using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Studio.API.APIs.Controllers.Base;
using Studio.API.Business.Domain.CQRS.Commands.Locations;
using Studio.API.Business.Domain.CQRS.Queries.Locations;
using Studio.API.Business.Domain.Models.Locations;
using Studio.API.Business.Domain.Models.Messages;
using Studio.API.Business.Domain.Results.Locations;
using Studio.API.Business.Domain.Results.Messages;

namespace Studio.API.APIs.Controllers.Countrys
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
