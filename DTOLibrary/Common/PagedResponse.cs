using DTOLibrary.Common;
using Microsoft.EntityFrameworkCore;

namespace DTOLibrary.Common
{
    public class PagedResponse<T>
    {
        public IEnumerable<T> Data { get; set; } = new List<T>();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public string NextPage { get; set; }
        public string PreviousPage { get; set; }

        public bool HasPrevious => PageNumber > 1;
        public bool HasNext => PageNumber < TotalPages;

        public PagedResponse()
        {
        }

        public PagedResponse(IEnumerable<T> data, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            PageNumber = pageNumber;
            TotalPages = (int) Math.Ceiling(count / (double) pageSize);

            Data = data;
        }

        public static async Task<PagedResponse<T>> ToPagedList(IQueryable<T> source, PaginationFilter pagination)
        {
            var count = source.Count();
            var pageNumber = pagination.PageNumber;
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            var pageSize = pagination.PageSize;
            var skip = (pageNumber - 1) * pageSize;
            List<T> items;
            if (pageSize == -1)
            {
                items = await source.ToListAsync();
            }
            else
            {
                items = await source.Skip(skip).Take(pageSize).ToListAsync();
            }

            return new PagedResponse<T>(items, count, pageNumber, pageSize);
        }
    }
}