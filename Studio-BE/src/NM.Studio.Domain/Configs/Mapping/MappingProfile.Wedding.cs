using AutoMapper;
using NM.Studio.Domain.CQRS.Commands.Weddings;
using NM.Studio.Domain.Entities.Weddings;
using NM.Studio.Domain.Models.Weddings;
using NM.Studio.Domain.Results.Weddings;

namespace NM.Studio.Domain.Configs.Mapping
{
    public partial class MappingProfile : Profile
    {
        private void WeddingMapping()
        {
            CreateMap<Wedding, WeddingResult>().ReverseMap();
            CreateMap<Wedding, WeddingCreateCommand>().ReverseMap();
            CreateMap<Wedding, WeddingView>().ReverseMap();
            CreateMap<Wedding, WeddingUpdateCommand>().ReverseMap();
        }
    }
}
