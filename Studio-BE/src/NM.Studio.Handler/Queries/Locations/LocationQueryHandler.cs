using MediatR;
using NM.Studio.Domain.Contracts.Services.Locations;
using NM.Studio.Domain.CQRS.Queries.Locations;
using NM.Studio.Domain.Models.Locations;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Results.Locations;
using NM.Studio.Handler.Queries.Base;

namespace NM.Studio.Handler.Queries.Locations
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
            return _locationService.GetAll(cancellationToken);
        }

        public Task<MessageResult<LocationResult>> Handle(LocationGetByIdQuery request, CancellationToken cancellationToken)
        {
            return _locationService.GetById<LocationResult>(request.Id);
        }
    }
}
