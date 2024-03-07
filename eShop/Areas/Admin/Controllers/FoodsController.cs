using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class FoodsController(IProductService productService,
                                  ICategoryService categoryService,
                                  IUploadService uploadService) : Controller
    {
        private readonly IProductService _productService = productService;
        private readonly ICategoryService _categoryService = categoryService;
        private readonly IUploadService _uploadService = uploadService;

        public IActionResult Index(int pageNumber = 1)
        {
            var foods = _productService.GetAll();
            var pageModel = new PageModel<ProductDto>(foods, pageNumber, 5);

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
            var p = products.FirstOrDefault(x => x.Id == id);


            //ProductDto productDto = new ProductDto()
            //{
            //    Name = p.Name,
            //    Id = p.Id,
            //    Category = p.Category,
            //    CategoryId = p.Category.Id,
            //    Price = p.Price,
            //    Description = p.Description,
            //    ImageUrl = p.ImageUrl,

            //};

            return View(p);
        }
        public IActionResult Delete(int id)
        {
            try
            {
                _productService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (CustomExeption)
            {

                return RedirectToAction("eror", "home", new { url = "/foods/index" });
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var products = _productService.GetAll();
                var product = products.FirstOrDefault(x => x.Id == id);
                var categories = _categoryService.GetAll();


                UpdateProductDto updateProductDto = new UpdateProductDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    CategoryId = product.Category.Id,
                    Categories = categories,
                    Category = product.Category,


                };


                return View(updateProductDto);
            }



            catch (CustomExeption)
            {

                return RedirectToAction("eror", "home", new { url = "/foods/index" });
            }
        }
        [HttpPost]
        public IActionResult Edit(UpdateProductDto dto)
        {
            try
            {
                _productService.Update(dto);
                return RedirectToAction("index");
            }
            catch (CustomExeption ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(dto);
            }
        }
    }
}
