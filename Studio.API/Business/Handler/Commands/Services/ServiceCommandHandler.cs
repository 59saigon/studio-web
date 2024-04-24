using MediatR;
using Studio.API.Business.Domain.Contracts.Services.Services;
using Studio.API.Business.Domain.CQRS.Commands.Services;
using Studio.API.Business.Domain.Models.Messages;
using Studio.API.Business.Domain.Models.Services;
using Studio.API.Business.Handler.Commands.Base;

namespace Studio.API.Business.Handler.Commands.Services
{
    public class ServiceCommandHandler : BaseCommandHandler<ServiceView>,
        IRequestHandler<ServiceCreateCommand, MessageView<ServiceView>>,
        IRequestHandler<ServiceUpdateCommand, MessageView<ServiceView>>,
        IRequestHandler<ServiceDeleteCommand, MessageView<ServiceView>>
    {
        protected readonly IServiceService _serviceService;
        public ServiceCommandHandler(IServiceService serviceService) : base(serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<MessageView<ServiceView>> Handle(ServiceCreateCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.CreateOrUpdate<ServiceView>(request);
            return msgView;
        }

        public async Task<MessageView<ServiceView>> Handle(ServiceUpdateCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.CreateOrUpdate<ServiceView>(request);
            return msgView;
        }

        public async Task<MessageView<ServiceView>> Handle(ServiceDeleteCommand request, CancellationToken cancellationToken)
        {
            var msgView = await _baseService.DeleteById<ServiceView>(request.Id);
            return msgView;
        }
    }
}
