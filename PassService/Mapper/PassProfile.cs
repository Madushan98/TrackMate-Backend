using AuthService.Domain.Filters;
using AuthService.Models.Request.Queries;
using AutoMapper;
using DAOLibrary.Pass;
using DAOLibrary.User;
using DTOLibrary.Common;
using DTOLibrary.PassDto;
using DTOLibrary.UserDto;

namespace PassService.Mapper;

public class PassProfile : Profile
{
    public PassProfile()
    {
        CreateMap<PassDao, CreatePassRequest>().ReverseMap();
        CreateMap<PassDao, PassResponse>().ReverseMap();
        CreateMap<PaginationRequest, PaginationFilter>().ReverseMap();
        CreateMap<GetAllUserQuery, UserFilter>().ReverseMap();
    }
}