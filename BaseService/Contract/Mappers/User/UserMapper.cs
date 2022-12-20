using AuthService.Domain.Filters;
using AuthService.Models.Request.Queries;
using AutoMapper;
using DAOLibrary.User;
using DTOLibrary.Common;
using DTOLibrary.UserDto;


namespace BaseService.Contract.Mappers.User;
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDao, CreateUserRequest>().ReverseMap();
        CreateMap<UserDao, UserResponse>().ReverseMap();
        CreateMap<PaginationRequest, PaginationFilter>().ReverseMap();
        CreateMap<GetAllUserQuery, UserFilter>().ReverseMap();
        CreateMap<UserDao, UserUpdateRequest>().ReverseMap();

    }
}