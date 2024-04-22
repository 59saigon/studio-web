using MediatR;
using Studio.API.Business.Domain.CQRS.Queries.Common;
using Studio.API.Business.Domain.Models.Base;
using Studio.API.Business.Domain.Models.Messages;
using Studio.API.Business.Domain.Results.Bases;
using Studio.API.Business.Domain.Results.Messages;

namespace Studio.API.Business.Domain.CQRS.Queries.Base
{
    public abstract class BaseQuery
    {
    }
    public class GetAllQuery<TResult> : GetQueryableQuery, IRequest<MessageResults<TResult>> where TResult : BaseResult
    {
        
    }
    public class GetByIdQuery<TResult> : GetQueryableQuery, IRequest<MessageResult<TResult>> where TResult : BaseResult
    {
        public Guid Id { get; set; }
        //public GetByIdQuery()
        //{

        //}
        //public GetByIdQuery(Guid id) : this()
        //{
        //    Id = id;
        //}
    }
}
