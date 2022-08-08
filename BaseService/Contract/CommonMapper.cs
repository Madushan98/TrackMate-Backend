using AutoMapper;
using DTOLibrary;
using DTOLibrary.Common;

namespace Base.Contract
{
    public class CommonMapper: Profile
    {
        public CommonMapper()
        {
            CreateMap<PaginationFilter, PaginationRequest>().ReverseMap();
        }
    }
}