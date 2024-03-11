using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Studio.API.DTOs;
using Studio.API.Models;
using Studio.API.Repositories.Interfaces;
using Studio.API.Services.Interfaces;
using System.Diagnostics.CodeAnalysis;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Studio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MomentController : ControllerBase
    {
        private readonly I_MomentService _MomentService;

        public MomentController(I_MomentService momentService)
        {
            _MomentService = momentService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MomentDto>>> Get()
        {
            if(await _MomentService.GetMoments() != null)
            {
                return Ok(await _MomentService.GetMoments());
            }
            return BadRequest(ModelState);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] MomentDto value)
        {   
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //check empty or null
            if (_MomentService.IsMomentDtoEmpty(value))
            {
                return BadRequest(ModelState);
            }

            if(await _MomentService.CreateMoment(value))
            {
                return Ok(ModelState);
            }
            
            return BadRequest(ModelState);

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //check empty or null
            if (id == Guid.Empty)
            {
                return BadRequest(ModelState);
            }

            if (await _MomentService.DeleteMoment(id))
            {
                return Ok(ModelState);
            }

            return BadRequest(ModelState);
        }
    }
}
