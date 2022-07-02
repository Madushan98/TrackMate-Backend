using Microsoft.AspNetCore.Mvc;

namespace DTOLibrary.Common
{
    public class PaginationRequest
    {
        [FromQuery(Name = "pageNumber")] public int PageNumber { get; set; }
        [FromQuery(Name = "pageSize")] public int PageSize { get; set; }

        public PaginationRequest()
        {
            PageNumber = 1;
            PageSize = -1;
        }
    }
}