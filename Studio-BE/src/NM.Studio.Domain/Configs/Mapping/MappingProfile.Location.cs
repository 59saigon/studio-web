using AutoMapper;
using NM.Studio.Domain.CQRS.Commands.Locations;
using NM.Studio.Domain.Entities.Locations;
using NM.Studio.Domain.Models.Locations;
using NM.Studio.Domain.Results.Locations;

namespace NM.Studio.Domain.Configs.Mapping
{
    public partial class MappingProfile : Profile
    {
        private void LocationMapping()
        {
            CreateMap<Location, LocationResult>().ReverseMap();
            CreateMap<Location, LocationCreateCommand>().ReverseMap();
            CreateMap<Location, LocationView>().ReverseMap();
            CreateMap<Location, LocationUpdateCommand>().ReverseMap();

            CreateMap<City, CityResult>().ReverseMap();
            CreateMap<City, CityCreateCommand>().ReverseMap();
            CreateMap<City, CityView>().ReverseMap();
            CreateMap<City, CityUpdateCommand>().ReverseMap();

            CreateMap<Country, CountryResult>().ReverseMap();
            CreateMap<Country, CountryCreateCommand>().ReverseMap();
            CreateMap<Country, CountryView>().ReverseMap();
            CreateMap<Country, CountryUpdateCommand>().ReverseMap();
        }
    }
}
