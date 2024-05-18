using MediatR;
using NM.Studio.Domain.CQRS.Commands.Locations;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Domain.Models.Locations;
using NM.Studio.Handler.Commands.Base;
using NM.Studio.Domain.Contracts.Services.Locations;

namespace NM.Studio.Handler.Commands.Locations
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
