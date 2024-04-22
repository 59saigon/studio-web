using MediatR;
using Microsoft.AspNetCore.Mvc;
using Studio.API.Business.Domain.Models.Base;

namespace Studio.API.APIs.Controllers.Base
{
    public abstract class BaseController<TView> : BaseController where TView : BaseView
    {
        protected BaseController(IMediator mediator) : base(mediator)
        {

        }
        
    }
}
