using AutoMapper;
using Studio.API.Business.Domain.Entities.Weddings;
using Studio.API.Business.Domain.Results.Weddings;

namespace Studio.API.Business.Domain.Configs.Mapping
{
    public partial class MappingProfile
    {
        public MappingProfile()
        {
            WeddingMapping();
        }
        
    }
}
