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
    public class LocationService : BaseService<Location>, ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _locationRepository = unitOfWork.LocationRepository;
        }

        public async Task<MessageResults<LocationResult>> GetAll(CancellationToken cancellationToken = default)
        {
            var queryable = _baseRepository.GetQueryable();
            var results = await queryable.Where(entity => !entity.IsDeleted)
                .Include(entity => entity.City)
                .ToListAsync();

            // map 
            var content = _mapper.Map<IList<Location>, List<LocationResult>>(results);
            var msgResults = AppMessage.GetMessageResults<LocationResult>(content);

            return msgResults;
        }
    }
}
