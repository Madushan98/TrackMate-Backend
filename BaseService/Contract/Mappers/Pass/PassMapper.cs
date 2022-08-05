using AutoMapper;
using DAOLibrary.Pass;
using DTOLibrary.PassDto;

namespace BaseService.Contract.Mappers.Pass;

public class PassMapper : Profile
{
    public PassMapper()
    {
        CreateMap<CreatePassRequest, PassDao>().ReverseMap();
        CreateMap<PassUpdateRequest, PassDao>().ReverseMap();
        CreateMap<PassDao, PassResponse>().ReverseMap();
    }
}