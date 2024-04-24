using MediatR;
using Microsoft.AspNetCore.Mvc;
using Studio.API.APIs.Controllers.Base;
using Studio.API.Business.Domain.CQRS.Commands.Services;
using Studio.API.Business.Domain.CQRS.Queries.Services;
using Studio.API.Business.Domain.Models.Messages;
using Studio.API.Business.Domain.Models.Services;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Results.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Studio.API.APIs.Controllers.Services
{
    [Route("api/service")]
    public class ServiceController : BaseController
    {
        public ServiceController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("get-service-list")]
        public async Task<IActionResult> GetAll([FromBody] ServiceGetAllQuery serviceGetAllQuery)
        {
            MessageResults<ServiceResult> messageResult = await _mediator.Send(serviceGetAllQuery);
            return Ok(messageResult);
        }

        // GET api/<ServiceController>/5
        [HttpPost("get-by-id")]
        public async Task<IActionResult> GetById([FromBody] ServiceGetByIdQuery serviceGetByIdQuery)
        {
            MessageResult<ServiceResult> messageResult = await _mediator.Send(serviceGetByIdQuery);
            return Ok(messageResult);
        }

        // POST api/<ServiceController>
        [HttpPost("create-service")]
        public async Task<IActionResult> Create([FromBody] ServiceCreateCommand serviceCreateCommand)
        {
            MessageView<ServiceView> messageView = await _mediator.Send(serviceCreateCommand);
            return Ok(messageView);
        }

        // PUT api/<ServiceController>/5
        [HttpPost("update-service")]
        public async Task<IActionResult> Update([FromBody] ServiceUpdateCommand serviceUpdateCommand)
        {
            MessageView<ServiceView> messageView = await _mediator.Send(serviceUpdateCommand);
            return Ok(messageView);
        }


        // DELETE api/<ServiceController>/5
        [HttpPost("delete-service")]
        public async Task<IActionResult> Delete([FromBody] ServiceDeleteCommand serviceDeleteCommand)
        {
            MessageView<ServiceView> messageView = await _mediator.Send(serviceDeleteCommand);
            return Ok(messageView);
        }
    }
}
