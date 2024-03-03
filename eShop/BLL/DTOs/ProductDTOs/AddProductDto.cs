namespace eShop.BLL.DTOs.ProductDTOs
{
    public class AddProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public IFormFile Image { get; set; }

        public int CategoryId { get; set; }

        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    }
}
