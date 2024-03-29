﻿using AutoMapper;
using DAOLibrary.Pass;
using DTOLibrary.PassDto;

namespace BaseService.Contract.Mappers;

public class PassMapper : Profile
{
    public PassMapper()
    {
        CreateMap<CreatePassRequest, PassDao>().ReverseMap();
        CreateMap<PassUpdateRequest, PassDao>().ReverseMap();
        CreateMap<PassDao, PassResponse>().ReverseMap();
        CreateMap<PassData, PassDataMap>().ReverseMap();
    }
}