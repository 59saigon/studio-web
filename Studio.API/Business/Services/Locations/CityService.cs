using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    public class CityService : BaseService<City>, ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _cityRepository = unitOfWork.CityRepository;
        }

        public async Task<MessageResults<CityResult>> GetAll(CancellationToken cancellationToken = default)
        {
            var queryable = _baseRepository.GetQueryable();
            var results = await queryable.Where(entity => !entity.IsDeleted)
                .Include(entity => entity.Country)
                .ToListAsync();

            // map 
            var content = _mapper.Map<IList<City>, List<CityResult>>(results);
            var msgResults = AppMessage.GetMessageResults<CityResult>(content);

            return msgResults;
        }
    }
}
