using MediatR;
using NM.Studio.Domain.Contracts.Services.Locations;
using NM.Studio.Domain.CQRS.Queries.Locations;
using NM.Studio.Domain.Models.Locations;
using NM.Studio.Domain.Results.Locations;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Handler.Queries.Base;

namespace NM.Studio.Handler.Queries.Locations
{
    public class CountryQueryHandler : BaseQueryHandler<CountryView>,
        IRequestHandler<CountryGetAllQuery, MessageResults<CountryResult>>,
        IRequestHandler<CountryGetByIdQuery, MessageResult<CountryResult>>
    {
        protected readonly ICountryService _countryService;
        public CountryQueryHandler(ICountryService countryService) : base(countryService)
        {
            _countryService = countryService;
        }

        public Task<MessageResults<CountryResult>> Handle(CountryGetAllQuery request, CancellationToken cancellationToken)
        {
            return _countryService.GetAll(cancellationToken);
        }

        public Task<MessageResult<CountryResult>> Handle(CountryGetByIdQuery request, CancellationToken cancellationToken)
        {
            return _countryService.GetById<CountryResult>(request.Id);
        }
    }
}
