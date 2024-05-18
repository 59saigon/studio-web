using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NM.Studio.Domain.Contracts.Repositories.Locations;
using NM.Studio.Domain.Contracts.Services.Locations;
using NM.Studio.Domain.Contracts.UnitOfWorks;
using NM.Studio.Domain.Entities.Locations;
using NM.Studio.Domain.Results.Locations;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Utilities;
using NM.Studio.Services.Bases;

namespace NM.Studio.Services.Locations
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
