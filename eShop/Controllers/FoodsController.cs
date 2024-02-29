using eShop.BLL.Common;
using eShop.BLL.DTOs.ProductDTOs;
using eShop.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    public class FoodsController(IProductService productService,
                                  ICategoryService categoryService,
                                  IUploadService uploadService) : Controller
    {
        private readonly IProductService _productService = productService;
        private readonly ICategoryService _categoryService = categoryService;
        private readonly IUploadService _uploadService = uploadService;

        public IActionResult Index()
        {
            var foods = _productService.GetAll();
            var pageModel = new PageModel<ProductDto>(foods, 1);

            return View(pageModel);
        }


        public IActionResult Add()
        {
            var categories = _categoryService.GetAll();
            AddProductDto addProductDto = new AddProductDto()
            {
                Categories = categories,
            };
            return View(addProductDto);
        }

        [HttpPost]
        public IActionResult Add(AddProductDto productDto)
        {
            try
            {
                _productService.Create(productDto);
                return RedirectToAction("index");
            }
            catch (CustomExeption ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(productDto);

            }
        }
        public IActionResult Detail(int id)
        {
            var products = _productService.GetAll();
            var prod = products.FirstOrDefault(x => x.Id == id);



            return View(prod);
        }
        public IActionResult Delete(int id)
        {

            var prod = _productService.GetById(id);
            if (prod != null)
            {
                _productService.Delete(prod.Id);
            }
            return RedirectToAction("index");
        }
    }
}
