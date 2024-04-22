using AutoMapper;
using Studio.API.Business.Domain.CQRS.Commands.Weddings;
using Studio.API.Business.Domain.Entities.Weddings;
using Studio.API.Business.Domain.Models.Weddings;
using Studio.API.Business.Domain.Results.Weddings;

namespace Studio.API.Business.Domain.Configs.Mapping
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
