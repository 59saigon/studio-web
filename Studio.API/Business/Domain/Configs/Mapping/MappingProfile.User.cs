using AutoMapper;
using Studio.API.Business.Domain.CQRS.Commands.Users;
using Studio.API.Business.Domain.Entities.Users;
using Studio.API.Business.Domain.Models.Users;
using Studio.API.Business.Domain.Results.Users;

namespace Studio.API.Business.Domain.Configs.Mapping
{
    public partial class MappingProfile : Profile
    {
        private void UserMapping()
        {
            CreateMap<User, UserResult>().ReverseMap();
            CreateMap<User, UserCreateCommand>().ReverseMap();
            CreateMap<User, UserView>().ReverseMap();
            CreateMap<User, UserUpdateCommand>().ReverseMap();

            CreateMap<Role, RoleResult>().ReverseMap();
            CreateMap<Role, RoleView>().ReverseMap();
        }
    }
}
