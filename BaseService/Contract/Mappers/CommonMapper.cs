using AutoMapper;
using DTOLibrary;
using DTOLibrary.Common;


namespace BaseService.Contract.Mappers
{
    public class CommonMapper: Profile
    {
        public CommonMapper()
        {
            CreateMap<PaginationFilter, PaginationQueryRequest>().ReverseMap();
        }
    }
}