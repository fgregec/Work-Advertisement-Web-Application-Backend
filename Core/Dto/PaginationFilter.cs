
namespace Core.Dto
{
    public class PaginationFilter<T> where T : class
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<T> Data { get; set; }

        public PaginationFilter(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public PaginationFilter()
        {
            PageIndex = 1;
            PageSize = 10;
        }
    }
}
