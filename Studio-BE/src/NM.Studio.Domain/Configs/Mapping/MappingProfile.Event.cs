using AutoMapper;
using NM.Studio.Domain.CQRS.Commands.Events;
using NM.Studio.Domain.Entities.Events;
using NM.Studio.Domain.Models.Events;
using NM.Studio.Domain.Results.Events;

namespace NM.Studio.Domain.Configs.Mapping
{
    public partial class MappingProfile : Profile
    {
        private void EventMapping()
        {
            CreateMap<Event, EventResult>().ReverseMap();
            CreateMap<Event, EventCreateCommand>().ReverseMap();
            CreateMap<Event, EventView>().ReverseMap();
            CreateMap<Event, EventUpdateCommand>().ReverseMap();
        }
    }
}
