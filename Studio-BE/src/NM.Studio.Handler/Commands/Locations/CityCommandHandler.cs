using MediatR;
using NM.Studio.Domain.Contracts.Services.Locations;
using NM.Studio.Domain.CQRS.Commands.Locations;
using NM.Studio.Domain.Models.Locations;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Handler.Commands.Base;

namespace NM.Studio.Handler.Commands.Locations
{
    public class CityCommandHandler : BaseCommandHandler<CityView>,
        IRequestHandler<CityCreateCommand, MessageView<CityView>>,
        IRequestHandler<CityUpdateCommand, MessageView<CityView>>,
        IRequestHandler<CityDeleteCommand, MessageView<CityView>>
    {
        protected readonly ICityService _cityService;
        public CityCommandHandler(ICityService cityService) : base(cityService)
        {
            _cityService = cityService;
        }

        public async Task<MessageView<CityView>> Handle(CityCreateCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.CreateOrUpdate<CityView>(request);
            return msgView;
        }

        public async Task<MessageView<CityView>> Handle(CityUpdateCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.CreateOrUpdate<CityView>(request);
            return msgView;
        }

        public async Task<MessageView<CityView>> Handle(CityDeleteCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.DeleteById<CityView>(request.Id);
            return msgView;
        }
    }
}
