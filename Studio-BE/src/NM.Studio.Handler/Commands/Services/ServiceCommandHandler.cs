using MediatR;
using NM.Studio.Domain.Contracts.Services.Services;
using NM.Studio.Domain.CQRS.Commands.Services;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Domain.Models.Services;
using NM.Studio.Handler.Commands.Base;

namespace NM.Studio.Handler.Commands.Services
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
