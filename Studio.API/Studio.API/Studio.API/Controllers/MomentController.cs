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
        public ActionResult<IEnumerable<MomentDto>> Get()
        {
            if(_MomentService.GetMoments() != null)
            {
                return Ok(_MomentService.GetMoments());
            }
            return BadRequest("Can not get list");
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] MomentDto value)
        {   
            if(_MomentService.CreateMoment(value))
            {
                return Ok("Good");
            }
            return BadRequest("Can not create moment");

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
