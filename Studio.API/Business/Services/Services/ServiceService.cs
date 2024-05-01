using AutoMapper;
using Serilog;
using Studio.API.Business.Domain.Contracts.Repositories.Services;
using Studio.API.Business.Domain.Contracts.Services.Services;
using Studio.API.Business.Domain.Contracts.UnitOfWorks;
using Studio.API.Business.Domain.CQRS.Queries.Services;
using Studio.API.Business.Domain.Entities.Services;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Results.Services;
using Studio.API.Business.Domain.Utilities;
using Studio.API.Business.Services.Bases;

namespace Studio.API.Business.Services.Services
{
    public class ServiceService : BaseService<Service>, IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _serviceRepository = _unitOfWork.ServiceRepository;
        }
        public async Task<MessageResults<ServiceResult>> GetAll(ServiceGetAllQuery x, CancellationToken cancellationToken = default)
        {
            var services = await _serviceRepository.GetAllWithInclude(x, cancellationToken);
            // map 
            var content = _mapper.Map<IList<Service>, List<ServiceResult>>(services);
            var msgResults = AppMessage.GetMessageResults<ServiceResult>(content);

            return msgResults;
        }

    }
}
