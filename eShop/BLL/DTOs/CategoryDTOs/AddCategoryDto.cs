﻿namespace eShop.BLL.DTOs.CategoryDTOs
{
    public class AddCategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public IFormFile Image { get; set; }

    }
}