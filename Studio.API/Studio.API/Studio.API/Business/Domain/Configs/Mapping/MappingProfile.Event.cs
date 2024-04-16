using AutoMapper;
using Studio.API.Business.Domain.CQRS.Commands.Events;
using Studio.API.Business.Domain.Entities.Events;
using Studio.API.Business.Domain.Models.Events;
using Studio.API.Business.Domain.Results.Events;

namespace Studio.API.Business.Domain.Configs.Mapping
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
