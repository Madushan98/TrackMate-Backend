using AuthService.Domain.Filters;
using AuthService.Models.Request.Queries;
using AutoMapper;
using DAOLibrary.Organization;
using DAOLibrary.User;
using DTOLibrary.Common;
using DTOLibrary.OrganizationDto;
using DTOLibrary.UserDto;

namespace BaseService.Contract.Mappers.Organization;

public class OrganizationProfile : Profile
{
    public OrganizationProfile() 
    {
        CreateMap<OrganizationDao, CreateOrganizationRequest>().ReverseMap();
        CreateMap<OrganizationDao, OrganizationResponse>().ReverseMap();
        CreateMap<PaginationRequest, PaginationFilter>().ReverseMap();
  
    }
}