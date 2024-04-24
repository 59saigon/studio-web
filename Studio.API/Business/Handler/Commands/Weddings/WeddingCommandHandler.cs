using MediatR;
using Studio.API.Business.Domain.Contracts.Services.Bases;
using Studio.API.Business.Domain.Contracts.Services.Weddings;
using Studio.API.Business.Domain.CQRS.Commands.Weddings;
using Studio.API.Business.Domain.CQRS.Queries.Weddings;
using Studio.API.Business.Domain.Models.Messages;
using Studio.API.Business.Domain.Models.Weddings;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Results.Weddings;
using Studio.API.Business.Handler.Commands.Base;

namespace Studio.API.Business.Handler.Commands.Weddings
{
    public class WeddingCommandHandler : BaseCommandHandler<WeddingView>,
        IRequestHandler<WeddingCreateCommand, MessageView<WeddingView>>,
        IRequestHandler<WeddingUpdateCommand, MessageView<WeddingView>>,
        IRequestHandler<WeddingDeleteCommand, MessageView<WeddingView>>
    {
        protected readonly IWeddingService _weddingService;
        public WeddingCommandHandler(IWeddingService weddingService) : base(weddingService)
        {
            _weddingService = weddingService;
        }

        public async Task<MessageView<WeddingView>> Handle(WeddingCreateCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.CreateOrUpdate<WeddingView>(request);
            return msgView;
        }

        public async Task<MessageView<WeddingView>> Handle(WeddingUpdateCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.CreateOrUpdate<WeddingView>(request);
            return msgView;
        }

        public async Task<MessageView<WeddingView>> Handle(WeddingDeleteCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.DeleteById<WeddingView>(request.Id);
            return msgView;
        }
    }
}
