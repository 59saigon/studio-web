using MediatR;
using NM.Studio.Domain.Contracts.Services.Locations;
using NM.Studio.Domain.CQRS.Queries.Locations;
using NM.Studio.Domain.Models.Locations;
using NM.Studio.Domain.Results.Locations;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Handler.Queries.Base;

namespace NM.Studio.Handler.Queries.Locations
{
    public class CityQueryHandler : BaseQueryHandler<CityView>,
        IRequestHandler<CityGetAllQuery, MessageResults<CityResult>>,
        IRequestHandler<CityGetByIdQuery, MessageResult<CityResult>>
    {
        protected readonly ICityService _cityService;
        public CityQueryHandler(ICityService cityService) : base(cityService)
        {
            _cityService = cityService;
        }

        public Task<MessageResults<CityResult>> Handle(CityGetAllQuery request, CancellationToken cancellationToken)
        {
            return _cityService.GetAll(cancellationToken);
        }

        public Task<MessageResult<CityResult>> Handle(CityGetByIdQuery request, CancellationToken cancellationToken)
        {
            return _cityService.GetById<CityResult>(request.Id);
        }
    }
}
