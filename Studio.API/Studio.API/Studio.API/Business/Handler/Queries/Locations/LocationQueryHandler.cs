using MediatR;
using Studio.API.Business.Domain.Contracts.Services.Locations;
using Studio.API.Business.Domain.CQRS.Queries.Locations;
using Studio.API.Business.Domain.Models.Locations;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Results.Locations;
using Studio.API.Business.Handler.Queries.Base;

namespace Studio.API.Business.Handler.Queries.Locations
{
    public class LocationQueryHandler : BaseQueryHandler<LocationView>,
        IRequestHandler<LocationGetAllQuery, MessageResults<LocationResult>>,
        IRequestHandler<LocationGetByIdQuery, MessageResult<LocationResult>>
    {
        protected readonly ILocationService _locationService;
        public LocationQueryHandler(ILocationService locationService) : base(locationService)
        {
            _locationService = locationService;
        }

        public Task<MessageResults<LocationResult>> Handle(LocationGetAllQuery request, CancellationToken cancellationToken)
        {
            return _locationService.GetAll<LocationResult>();
        }

        public Task<MessageResult<LocationResult>> Handle(LocationGetByIdQuery request, CancellationToken cancellationToken)
        {
            return _locationService.GetById<LocationResult>(request.Id);
        }
    }
}
