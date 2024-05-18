using AutoMapper;
using NM.Studio.Domain.CQRS.Commands.Events.EventXPhotos;
using NM.Studio.Domain.Entities.Events;
using NM.Studio.Domain.Models.Events;
using NM.Studio.Domain.Results.Events;

namespace NM.Studio.Domain.Configs.Mapping
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
