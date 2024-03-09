using AutoMapper;
using Studio.API.DTOs;
using Studio.API.Models;
using System.Diagnostics.Metrics;

namespace Studio.API.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<MomentDto, Moment>();
            CreateMap<Moment, MomentDto>();

        }
    }
}
