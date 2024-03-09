namespace eShop.Models
{
    public class ProductViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
        public bool IsChecked { get; set; }
    }
}
