using eShop.BLL.Common;
using eShop.BLL.DTOs.ProductDTOs;
using eShop.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    public class ProductCantroller(ICategoryService categoryService,
                                   IProductService productService) : Controller
    {
        private readonly ICategoryService _categoryService = categoryService;
        private readonly IProductService _productService = productService;

        public IActionResult Index(int pageNumber = 1)
        {
            var products = _categoryService.GetAll();
            var pageModel = new PageModel<ProductDto>(products, pageNumber);

            return View();
        }
    }
}
