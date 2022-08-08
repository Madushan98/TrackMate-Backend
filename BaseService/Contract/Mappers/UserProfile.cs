using AuthService.Domain.Filters;
using AuthService.Models.Request.Queries;
using AutoMapper;
using DAOLIbrary.User;
using DTOLibrary.Common;
using DTOLibrary.UserDto;

namespace BaseService.Contract.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, CreateUserRequest>().ReverseMap();
        CreateMap<User, UserResponse>().ReverseMap();
        CreateMap<PaginationRequest, PaginationFilter>().ReverseMap();
        CreateMap<GetAllUserQuery, UserFilter>().ReverseMap();
    }
}