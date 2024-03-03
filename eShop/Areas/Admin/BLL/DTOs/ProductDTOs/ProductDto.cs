using eShop.Areas.Admin.BLL.DTOs.CategoryDTOs;

namespace eShop.Areas.Admin.BLL.DTOs.ProductDTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; } = new CategoryDto();
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    }
}
