using MediatR;
using Studio.API.Business.Domain.Contracts.Services.Locations;
using Studio.API.Business.Domain.CQRS.Queries.Locations;
using Studio.API.Business.Domain.Models.Locations;
using Studio.API.Business.Domain.Results.Locations;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Handler.Queries.Base;

namespace Studio.API.Business.Handler.Queries.Locations
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
