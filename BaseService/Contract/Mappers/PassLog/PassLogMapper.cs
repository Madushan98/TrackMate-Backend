using AutoMapper;
using DAOLibrary.Pass;
using DTOLibrary.PassDto;
using DTOLibrary.PassLogDto;

namespace BaseService.Contract.Mappers.PassLog;

public class PassLogMapper: Profile
{
    public PassLogMapper()
    {
        CreateMap<CreatePassLogRequest, PassLogDao>().ReverseMap();
        CreateMap<PassLogUpdateRequest, PassLogDao>().ReverseMap();
        CreateMap<PassLogDao, PassLogResponse>().ReverseMap();
    }
}