using MediatR;
using Studio.API.Business.Domain.Contracts.Services.Bases;
using Studio.API.Business.Domain.CQRS.Commands.Base;
using Studio.API.Business.Domain.Models.Base;
using Studio.API.Business.Domain.Models.Messages;
using Studio.API.Business.Handler.Queries.Base;

namespace Studio.API.Business.Handler.Commands.Base
{
    public abstract class BaseCommandHandler
    {
    }
    public abstract class BaseCommandHandler<TView> : BaseCommandHandler,
        IRequestHandler<CreateOrUpdateCommand<TView>, MessageView<TView>>,
        IRequestHandler<DeleteCommand<TView>, MessageView<TView>>
        where TView : BaseView
    {
        protected readonly IBaseService _baseService;

        protected BaseCommandHandler(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<MessageView<TView>> Handle(CreateOrUpdateCommand<TView> request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.CreateOrUpdate<TView>(request);
            return msgView;
        }

        public async Task<MessageView<TView>> Handle(DeleteCommand<TView> request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.DeleteById<TView>(request.Id);
            return msgView;
        }
    }
}
