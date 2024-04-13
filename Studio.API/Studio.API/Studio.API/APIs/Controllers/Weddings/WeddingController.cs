using MediatR;
using Microsoft.AspNetCore.Mvc;
using Studio.API.APIs.Controllers.Base;
using Studio.API.Business.Domain.CQRS.Queries.Weddings;
using Studio.API.Business.Domain.Models.Weddings;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Results.Weddings;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Studio.API.APIs.Controllers.Weddings
{
    [Route("api/wedding")]
    public class WeddingController : BaseController<WeddingView>
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
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WeddingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WeddingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WeddingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
