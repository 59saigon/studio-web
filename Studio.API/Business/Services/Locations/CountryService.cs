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
            var queryable = _baseRepository.GetQueryable();
            var results = await queryable.Where(entity => !entity.IsDeleted)
                .Include(entity => entity.Cities)
                .ToListAsync();

            // map 
            var content = _mapper.Map<IList<Country>, List<CountryResult>>(results);
            var msgResults = AppMessage.GetMessageResults<CountryResult>(content);

            return msgResults;
        }
    }
}
