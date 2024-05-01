using AutoMapper;
using Studio.API.Business.Domain.CQRS.Commands.Events.EventXServices;
using Studio.API.Business.Domain.Entities.Events;
using Studio.API.Business.Domain.Models.Events;
using Studio.API.Business.Domain.Results.Events;

namespace Studio.API.Business.Domain.Configs.Mapping
{
    public partial class MappingProfile : Profile
    {
        private void EventXServiceMapping()
        {
            CreateMap<EventXService, EventXServiceResult>().ReverseMap();
            CreateMap<EventXService, EventXServiceCreateCommand>().ReverseMap();
            CreateMap<EventXService, EventXServiceView>().ReverseMap();
            CreateMap<EventXService, EventXServiceUpdateCommand>().ReverseMap();
        }
    }
}
