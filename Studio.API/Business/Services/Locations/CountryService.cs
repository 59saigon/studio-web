using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Studio.API.Business.Domain.Contracts.Repositories.Locations;
using Studio.API.Business.Domain.Contracts.Services.Locations;
using Studio.API.Business.Domain.Contracts.UnitOfWorks;
using Studio.API.Business.Domain.Entities.Locations;
using Studio.API.Business.Domain.Results.Locations;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Utilities;
using Studio.API.Business.Services.Bases;

namespace Studio.API.Business.Services.Locations
{
    public class CountryService : BaseService<Country>, ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _countryRepository = unitOfWork.CountryRepository;
        }

        public async Task<MessageResults<CountryResult>> GetAll(CancellationToken cancellationToken = default)
        {
            var countries = await _countryRepository.GetAllWithInclude(cancellationToken);
            // map 
            var content = _mapper.Map<IList<Country>, List<CountryResult>>(countries);
            var msgResults = AppMessage.GetMessageResults<CountryResult>(content);

            return msgResults;
        }
    }
}
