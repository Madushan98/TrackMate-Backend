using System;

namespace DTOLibrary.Common
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = Int32.MaxValue;
    }
}