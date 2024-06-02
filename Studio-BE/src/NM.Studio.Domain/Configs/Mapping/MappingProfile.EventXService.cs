using AutoMapper;
using NM.Studio.Domain.CQRS.Commands.Events.EventXServices;
using NM.Studio.Domain.Entities.Events;
using NM.Studio.Domain.Models.Events;
using NM.Studio.Domain.Results.Events;

namespace NM.Studio.Domain.Configs.Mapping
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
