using AutoMapper;
using Studio.API.Business.Domain.CQRS.Commands.Services;
using Studio.API.Business.Domain.Entities.Services;
using Studio.API.Business.Domain.Models.Services;
using Studio.API.Business.Domain.Results.Services;

namespace Studio.API.Business.Domain.Configs.Mapping
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
