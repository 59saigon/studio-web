using AutoMapper;
using NM.Studio.Domain.CQRS.Commands.Services;
using NM.Studio.Domain.Entities.Services;
using NM.Studio.Domain.Models.Services;
using NM.Studio.Domain.Results.Services;

namespace NM.Studio.Domain.Configs.Mapping
{
    public partial class MappingProfile : Profile
    {
        private void ServiceMapping()
        {
            CreateMap<Service, ServiceResult>().ReverseMap();
            CreateMap<Service, ServiceCreateCommand>().ReverseMap();
            CreateMap<Service, ServiceView>().ReverseMap();
            CreateMap<Service, ServiceUpdateCommand>().ReverseMap();
        }
    }
}
