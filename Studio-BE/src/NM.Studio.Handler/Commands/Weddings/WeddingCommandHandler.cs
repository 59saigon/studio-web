using MediatR;
using NM.Studio.Domain.Contracts.Services.Bases;
using NM.Studio.Domain.Contracts.Services.Weddings;
using NM.Studio.Domain.CQRS.Commands.Weddings;
using NM.Studio.Domain.CQRS.Queries.Weddings;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Domain.Models.Weddings;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Results.Weddings;
using NM.Studio.Handler.Commands.Base;

namespace NM.Studio.Handler.Commands.Weddings
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
