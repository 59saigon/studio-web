using MediatR;
using NM.Studio.Domain.Contracts.Services.Weddings;
using NM.Studio.Domain.CQRS.Queries.Weddings;
using NM.Studio.Domain.Models.Weddings;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Results.Weddings;
using NM.Studio.Handler.Queries.Base;

namespace NM.Studio.Handler.Queries.Weddings
{
    public class WeddingQueryHandler : BaseQueryHandler<WeddingView>,
        IRequestHandler<WeddingGetAllQuery, MessageResults<WeddingResult>>,
        IRequestHandler<WeddingGetByIdQuery, MessageResult<WeddingResult>>
    {
        protected readonly IWeddingService _weddingService;
        public WeddingQueryHandler(IWeddingService weddingService) : base(weddingService)
        {
            _weddingService = weddingService;
        }

        public async Task<MessageResults<WeddingResult>> Handle(WeddingGetAllQuery request, CancellationToken cancellationToken)
        {
            return await _weddingService.GetAll<WeddingResult>();
        }

        public async Task<MessageResult<WeddingResult>> Handle(WeddingGetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _weddingService.GetById<WeddingResult>(request.Id);
        }
    }
}
