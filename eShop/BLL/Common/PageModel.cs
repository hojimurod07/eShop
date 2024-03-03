namespace eShop.BLL.Common
{
    public class PageModel<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalItemsCount { get; set; }
        public List<T> Items { get; set; } = new List<T>();

        public PageModel(List<T> items, int pageNumber, int pageSize = 5)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            TotalItemsCount = items.Count;
            TotalPages = (int)Math.Ceiling(TotalItemsCount / (double)pageSize);
            Items = items.Skip(pageSize * (pageNumber - 1))
                            .Take(pageSize)
                            .ToList();
        }

    }

}
