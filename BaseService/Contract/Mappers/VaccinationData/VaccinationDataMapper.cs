using AuthService.Domain.Filters;
using AuthService.Models.Request.Queries;
using AutoMapper;
using DAOLibrary.User;
using DAOLibrary.VaccinationData;
using DTOLibrary.Common;
using DTOLibrary.UserDto;
using DTOLibrary.VaccinationDataDto;

namespace BaseService.Contract.Mappers.VaccinationData;
public class VaccinationDataProfile : Profile
{
    public VaccinationDataProfile()
    {
        CreateMap<VaccinationDataDao, VaccinationDataCreateRequest>().ReverseMap();
        CreateMap<VaccinationDataDao, VaccinationDataUpdateRequest>().ReverseMap();
        CreateMap<VaccinationDataDao, VaccinationDataResponse>().ReverseMap();
    }
}