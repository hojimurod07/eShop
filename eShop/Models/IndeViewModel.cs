namespace eShop.Models
{
    public class IndeViewModel
    {
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public List<ProductDto> Products { get; set; } = new List<ProductDto> { };
        public int CategoryId { get; set; }
    }
}
