using Studio.API.Business.Domain.Results.Bases;
using Studio.API.Business.Domain.Results.Messages;


namespace Studio.API.Business.Domain.Contracts.Services.Bases
{
    public interface IBaseService
    {
        Task<MessageResults<TResult>> GetAll<TResult>() where TResult : BaseResult;
        Task<MessageResult<TResult>> GetById<TResult>(Guid id) where TResult : BaseResult;  
    }
}
