using eShop.BLL.Common;
using eShop.BLL.DTOs.ProductDTOs;
using eShop.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    public class FoodsController(IProductService productService) : Controller
    {
        private readonly IProductService _productService = productService;

        public IActionResult Index()
        {
            var foods = _productService.GetAll();
            var pageModel = new PageModel<ProductDto>(foods, 1);

            return View(pageModel);
        }
    }
}
