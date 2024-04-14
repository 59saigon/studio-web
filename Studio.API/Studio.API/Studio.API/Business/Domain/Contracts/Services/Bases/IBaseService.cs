using Studio.API.Business.Domain.CQRS.Commands.Base;
using Studio.API.Business.Domain.Models.Base;
using Studio.API.Business.Domain.Models.Messages;
using Studio.API.Business.Domain.Results.Bases;
using Studio.API.Business.Domain.Results.Messages;


namespace Studio.API.Business.Domain.Contracts.Services.Bases
{
    public interface IBaseService
    {
        Task<MessageResults<TResult>> GetAll<TResult>() where TResult : BaseResult;

        Task<MessageResult<TResult>> GetById<TResult>(Guid id) where TResult : BaseResult;

        Task<MessageView<TView>> CreateOrUpdate<TView>(CreateOrUpdateCommand<TView> createOrUpdateCommand) where TView : BaseView;

        Task<MessageView<TView>> DeleteById<TView>(Guid id) where TView : BaseView;  


    }
}
