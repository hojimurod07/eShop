using eShop.BLL.DTOs.CategoryDTOs;
using eShop.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Controllers
{
    public class CategoriesController(ICategoryService categoryService) : Controller
    {
        private readonly ICategoryService _categoryService = categoryService;

        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }
        [HttpGet]
        public ActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add(AddCategoryDto dto)
        {
            _categoryService.Create(dto);
            return RedirectToAction("Index");
        }
    }
}
