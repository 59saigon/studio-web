using MediatR;
using Studio.API.Business.Domain.Models.Base;
using Studio.API.Business.Domain.Models.Messages;

namespace Studio.API.Business.Domain.CQRS.Queries.Base
{
    public abstract class BaseQuery
    {
    }
    public class GetAllQuery<TView> : BaseQuery, IRequest<MessageViews<TView>> where TView : BaseView
    {
        
    }
    public class GetByIdQuery<TView> : BaseQuery, IRequest<MessageView<TView>> where TView : BaseView
    {
        public Guid Id { get; set; }
        public GetByIdQuery()
        {

        }
        public GetByIdQuery(Guid id) : this()
        {
            Id = id;
        }
    }
}
