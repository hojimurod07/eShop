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
        public IActionResult Filtered(int categoryId)
        {

            var categories = _categoryService.GetAll();
            var products = _productService.GetAll();
            var filteredProducts = products.Where(c => c.Category.Id == categoryId).ToList();

            IndeViewModel model = new IndeViewModel()
            {
                Categories = categories,
                Products = filteredProducts,
                CategoryId = categoryId
            };
            return View("Index", model);


        }


    }
}
