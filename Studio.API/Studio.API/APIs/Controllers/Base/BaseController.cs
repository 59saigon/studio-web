using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Studio.API.APIs.Controllers.Base
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected BaseController()
        {
        }
        protected BaseController(IMediator mediator) : this()
        {
            _mediator = mediator;
        }

       

    }
}
