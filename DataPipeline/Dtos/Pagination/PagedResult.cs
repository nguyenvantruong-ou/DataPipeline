namespace DataPipeline.Dtos.Pagination
{
    public class PagedResult<T>
    {
        public PagedResult(int totalItems = 0, int currentPage = 0, int pageSize = 0, List<T> items = null)
        {
            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            Items = items ?? new List<T>();
        }

        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int PageCount => (int)Math.Ceiling((double)TotalItems / PageSize);
        public List<T> Items { get; set; } = new();
    }

}
