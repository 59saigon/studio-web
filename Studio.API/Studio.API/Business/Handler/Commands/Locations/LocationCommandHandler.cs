using MediatR;
using Studio.API.Business.Domain.CQRS.Commands.Locations;
using Studio.API.Business.Domain.Models.Messages;
using Studio.API.Business.Domain.Models.Locations;
using Studio.API.Business.Handler.Commands.Base;
using Studio.API.Business.Domain.Contracts.Services.Locations;

namespace Studio.API.Business.Handler.Commands.Locations
{
    public class LocationCommandHandler : BaseCommandHandler<LocationView>,
        IRequestHandler<LocationCreateCommand, MessageView<LocationView>>,
        IRequestHandler<LocationUpdateCommand, MessageView<LocationView>>,
        IRequestHandler<LocationDeleteCommand, MessageView<LocationView>>
    {
        protected readonly ILocationService _locationService;
        public LocationCommandHandler(ILocationService locationService) : base(locationService)
        {
            _locationService = locationService;
        }

        public async Task<MessageView<LocationView>> Handle(LocationCreateCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.CreateOrUpdate<LocationView>(request);
            return msgView;
        }

        public async Task<MessageView<LocationView>> Handle(LocationUpdateCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.CreateOrUpdate<LocationView>(request);
            return msgView;
        }

        public async Task<MessageView<LocationView>> Handle(LocationDeleteCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.DeleteById<LocationView>(request.Id);
            return msgView;
        }
    }
}
