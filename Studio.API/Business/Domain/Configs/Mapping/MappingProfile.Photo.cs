using AutoMapper;
using Studio.API.Business.Domain.CQRS.Commands.Photos;
using Studio.API.Business.Domain.Entities.Photos;
using Studio.API.Business.Domain.Models.Photos;
using Studio.API.Business.Domain.Results.Photos;

namespace Studio.API.Business.Domain.Configs.Mapping
{
    public partial class MappingProfile : Profile
    {
        private void PhotoMapping()
        {
            CreateMap<Photo, PhotoResult>().ReverseMap();
            CreateMap<Photo, PhotoCreateCommand>().ReverseMap();
            CreateMap<Photo, PhotoView>().ReverseMap();
            CreateMap<Photo, PhotoUpdateCommand>().ReverseMap();
        }
    }
}
