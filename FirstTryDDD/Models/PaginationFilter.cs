namespace FirstTryDDD.API.Models
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PaginationFilter()
        {
            PageNumber = 1;
            PageSize = 5;
        }
        public PaginationFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageNumber < 5 ? 5 : pageSize;
        }

        public void RecheckValues()
        {
            PageNumber = PageNumber < 1 ? 1 : PageNumber;
            PageSize = PageSize < 5 ? 5 : PageSize;
        }

    }
}
