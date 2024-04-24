using MediatR;
using Studio.API.Business.Domain.Contracts.Services.Services;
using Studio.API.Business.Domain.CQRS.Queries.Services;
using Studio.API.Business.Domain.Models.Services;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Results.Services;
using Studio.API.Business.Handler.Queries.Base;

namespace Studio.API.Business.Handler.Queries.Services
{
    public class ServiceQueryHandler : BaseQueryHandler<ServiceView>,
        IRequestHandler<ServiceGetAllQuery, MessageResults<ServiceResult>>,
        IRequestHandler<ServiceGetByIdQuery, MessageResult<ServiceResult>>
    {
        protected readonly IServiceService _serviceService;
        public ServiceQueryHandler(IServiceService serviceService) : base(serviceService)
        {
            _serviceService = serviceService;
        }

        public Task<MessageResults<ServiceResult>> Handle(ServiceGetAllQuery request, CancellationToken cancellationToken)
        {
            return _serviceService.GetAll<ServiceResult>();
        }

        public Task<MessageResult<ServiceResult>> Handle(ServiceGetByIdQuery request, CancellationToken cancellationToken)
        {
            return _serviceService.GetById<ServiceResult>(request.Id);
        }
    }
}
