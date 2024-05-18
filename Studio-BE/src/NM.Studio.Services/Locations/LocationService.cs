using AutoMapper;
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
    public class LocationService : BaseService<Location>, ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _locationRepository = unitOfWork.LocationRepository;
        }

        public async Task<MessageResults<LocationResult>> GetAll(CancellationToken cancellationToken = default)
        {
            var locations = await _locationRepository.GetAllWithInclude(cancellationToken);
            // map 
            var content = _mapper.Map<IList<Location>, List<LocationResult>>(locations);
            var msgResults = AppMessage.GetMessageResults<LocationResult>(content);

            return msgResults;
        }
    }
}
