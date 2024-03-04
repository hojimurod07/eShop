using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    public class HomeController(ICategoryService categoryService,
                                IProductService productService) : Controller
    {

        private readonly ICategoryService _categoryService = categoryService;
        private readonly IProductService _productService = productService;

        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();
            var products = _productService.GetAll();
            IndeViewModel model = new IndeViewModel()
            {
                Categories = categories,
                Products = products
            };

            return View(model);
        }
    }
}
