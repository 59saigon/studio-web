using Studio.API.Business.Domain.Contracts.Services.Bases;
using Studio.API.Business.Domain.Models.Base;

namespace Studio.API.Business.Handler.Queries.Base
{
    public abstract class BaseQueryHandler
    {

    }
    public abstract class BaseQueryHandler<TView> : BaseQueryHandler
        where TView : BaseView
    {
        protected readonly IBaseService _baseService;

        protected BaseQueryHandler(IBaseService baseService)
        {
            _baseService = baseService;
        }

    }
}
