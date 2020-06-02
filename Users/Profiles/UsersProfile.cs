using AutoMapper;
using Users.Dtos;
using Users.Models;

namespace Users.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserForReadDto>();
            CreateMap<UserForCreateDto, User>();
            CreateMap< UserForUpdateDto,User>();
            CreateMap< User, UserForUpdateDto>();
        }
    }
}