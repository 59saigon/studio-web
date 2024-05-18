using AutoMapper;
using NM.Studio.Domain.CQRS.Commands.Photos;
using NM.Studio.Domain.Entities.Photos;
using NM.Studio.Domain.Models.Photos;
using NM.Studio.Domain.Results.Photos;

namespace NM.Studio.Domain.Configs.Mapping
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
