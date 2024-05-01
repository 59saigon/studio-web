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
using Studio.API.Data.Repositories.Locations;

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
            var cities = await _cityRepository.GetAllWithInclude(cancellationToken);
            // map 
            var content = _mapper.Map<IList<City>, List<CityResult>>(cities);
            var msgResults = AppMessage.GetMessageResults<CityResult>(content);

            return msgResults;
        }
    }
}
