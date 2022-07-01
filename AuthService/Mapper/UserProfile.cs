using AutoMapper;
using DAOLIbrary.User;
using DTOLibrary.UserDto;

namespace AuthService.Mapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserRequest>().ReverseMap();
        CreateMap<User, UserResponse>().ReverseMap();
    }
}