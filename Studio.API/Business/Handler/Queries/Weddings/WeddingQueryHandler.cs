using MediatR;
using Studio.API.Business.Domain.Contracts.Services.Weddings;
using Studio.API.Business.Domain.CQRS.Queries.Weddings;
using Studio.API.Business.Domain.Models.Weddings;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Results.Weddings;
using Studio.API.Business.Handler.Queries.Base;

namespace Studio.API.Business.Handler.Queries.Weddings
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

        public Task<MessageResults<WeddingResult>> Handle(WeddingGetAllQuery request, CancellationToken cancellationToken)
        {
            return _weddingService.GetAll<WeddingResult>();
        }

        public Task<MessageResult<WeddingResult>> Handle(WeddingGetByIdQuery request, CancellationToken cancellationToken)
        {
            return _weddingService.GetById<WeddingResult>(request.Id);
        }
    }
}
