using AutoMapper;
using Studio.API.Business.Domain.CQRS.Commands.Events.EventXPhotos;
using Studio.API.Business.Domain.Entities.Events;
using Studio.API.Business.Domain.Models.Events;
using Studio.API.Business.Domain.Results.Events;

namespace Studio.API.Business.Domain.Configs.Mapping
{
    public partial class MappingProfile : Profile
    {
        private void EventXPhotoMapping()
        {
            CreateMap<EventXPhoto, EventXPhotoResult>().ReverseMap();
            CreateMap<EventXPhoto, EventXPhotoCreateCommand>().ReverseMap();
            CreateMap<EventXPhoto, EventXPhotoView>().ReverseMap();
            CreateMap<EventXPhoto, EventXPhotoUpdateCommand>().ReverseMap();
        }
    }
}
