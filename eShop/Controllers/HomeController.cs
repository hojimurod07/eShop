using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    public class HomeController(ICategoryService categoryService,
                                IProductService productService) : Controller
    {

        private readonly ICategoryService _categoryService = categoryService;
        private readonly IProductService _productService = productService;

        public IActionResult Index(int categoryId = 0)
        {
            var categories = _categoryService.GetAll();
            var products = _productService.GetAll();
            if (categoryId == 0)
            {
                IndeViewModel model1 = new IndeViewModel()
                {
                    Categories = categories,
                    Products = products
                };
                return View(model1);

            }

            var filtered = products.Where(c => c.CategoryId == categoryId).ToList();
            IndeViewModel model = new IndeViewModel()
            {
                Categories = categories,
                Products = filtered
            };


            return View(model);
        }
        //public IActionResult Filtered(int categoryId)
        //{

        //    var categories = _categoryService.GetAll();
        //    var products = _productService.GetAll();
        //    var filteredProducts = products.Where(c => c.Category.Id == categoryId).ToList();

        //    IndeViewModel model = new IndeViewModel()
        //    {
        //        Categories = categories,
        //        Products = filteredProducts,
        //        CategoryId = categoryId
        //    };
        //    return RedirectToAction("Index", model);


        //}


    }
}
