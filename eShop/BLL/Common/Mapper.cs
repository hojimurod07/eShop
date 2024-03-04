namespace eShop.BLL.Common
{
    public static class Mapper
    {
        public static ProductDto ToProductDto(this Product product)

            => new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                CategoryId = product.Category.Id,
                Category = new CategoryDto
                {
                    Id = product.Category.Id,
                    Name = product.Category.Name,
                    ImagePath = product.Category.ImageUrl
                }

            };
        public static Product ToProduct(this ProductDto productDto)
            => new()
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description,
                ImageUrl = productDto.ImageUrl,
                CategoryId = productDto.Category.Id,
            };
    }

}
