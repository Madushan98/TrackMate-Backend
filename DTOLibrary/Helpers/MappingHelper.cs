using System.Collections.Generic;
using AutoMapper;
using DTOLibrary.Common;

namespace DTOLibrary.Helpers
{
    public static class MappingHelper
    {
        public static PagedResponse<TReturn> MapPagination<TReturn, TSource>(PagedResponse<TSource> source, IMapper mapper)
        {
            var categories = mapper.Map<IEnumerable<TReturn>>(source.Data);
            
            return new PagedResponse<TReturn>(categories, source.TotalCount, source.PageNumber, source.PageSize);;
        }
    }
}