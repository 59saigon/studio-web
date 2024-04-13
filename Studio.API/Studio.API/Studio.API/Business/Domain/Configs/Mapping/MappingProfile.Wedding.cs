using AutoMapper;
using Studio.API.Business.Domain.Entities.Weddings;
using Studio.API.Business.Domain.Results.Weddings;

namespace Studio.API.Business.Domain.Configs.Mapping
{
    public partial class MappingProfile : Profile
    {
        private void WeddingMapping()
        {
            CreateMap<WeddingResult, Wedding>();
            CreateMap<Wedding, WeddingResult>();
        }
    }
}
