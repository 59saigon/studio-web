using MediatR;
using Studio.API.Business.Domain.Contracts.Services.Locations;
using Studio.API.Business.Domain.CQRS.Commands.Locations;
using Studio.API.Business.Domain.Models.Locations;
using Studio.API.Business.Domain.Models.Messages;
using Studio.API.Business.Handler.Commands.Base;

namespace Studio.API.Business.Handler.Commands.Country
{
    public class CountryCommandHandler : BaseCommandHandler<CountryView>,
        IRequestHandler<CountryCreateCommand, MessageView<CountryView>>,
        IRequestHandler<CountryUpdateCommand, MessageView<CountryView>>,
        IRequestHandler<CountryDeleteCommand, MessageView<CountryView>>
    {
        protected readonly ICountryService _countryService;
        public CountryCommandHandler(ICountryService countryService) : base(countryService)
        {
            _countryService = countryService;
        }

        public async Task<MessageView<CountryView>> Handle(CountryCreateCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.CreateOrUpdate<CountryView>(request);
            return msgView;
        }

        public async Task<MessageView<CountryView>> Handle(CountryUpdateCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.CreateOrUpdate<CountryView>(request);
            return msgView;
        }

        public async Task<MessageView<CountryView>> Handle(CountryDeleteCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.DeleteById<CountryView>(request.Id);
            return msgView;
        }
    }
}
