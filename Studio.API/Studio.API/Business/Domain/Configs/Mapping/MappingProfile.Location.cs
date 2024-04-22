using AutoMapper;
using Studio.API.Business.Domain.CQRS.Commands.Locations;
using Studio.API.Business.Domain.Entities.Locations;
using Studio.API.Business.Domain.Models.Locations;
using Studio.API.Business.Domain.Results.Locations;

namespace Studio.API.Business.Domain.Configs.Mapping
{
    public partial class MappingProfile : Profile
    {
        private void LocationMapping()
        {
            CreateMap<Location, LocationResult>().ReverseMap();
            CreateMap<Location, LocationCreateCommand>().ReverseMap();
            CreateMap<Location, LocationView>().ReverseMap();
            CreateMap<Location, LocationUpdateCommand>().ReverseMap();
        }
    }
}
