using MediatR;
using Studio.API.Business.Domain.Contracts.Services.Locations;
using Studio.API.Business.Domain.CQRS.Queries.Locations;
using Studio.API.Business.Domain.Models.Locations;
using Studio.API.Business.Domain.Results.Locations;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Handler.Queries.Base;

namespace Studio.API.Business.Handler.Queries.Locations
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
