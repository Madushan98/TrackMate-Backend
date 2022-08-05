using Microsoft.AspNetCore.Mvc;

namespace DTOLibrary
{
    public class PaginationQueryRequest 
    {
        [FromQuery(Name = "pageNumber")] public int PageNumber { get; set; }
        [FromQuery(Name = "pageSize")] public int PageSize { get; set; }

        public PaginationQueryRequest()
        {
            PageNumber = 1;
            PageSize = 20;
        }
    }
}