using eShop.BLL.Common;
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
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Save(AddCategoryDto dto)
        {

            _categoryService.Create(dto);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            try
            {
                _categoryService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (CustomExeption)
            {

                return RedirectToAction("eror", "home", new { url = "/categories/index" });
            }

        }
    }
}
