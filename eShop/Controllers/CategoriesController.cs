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
        public IActionResult Edit(int id)
        {
            try
            {
                var category = _categoryService.GetById(id);
                UpdateCategoryDto dto = new UpdateCategoryDto()
                {
                    Id = category.Id,
                    Name = category.Name,
                    ImagePath = category.ImagePath,


                };
                return View(dto);
            }
            catch (CustomExeption)
            {

                return RedirectToAction("eror", "home", new { url = "/categories/index" });
            }
        }
        [HttpPost]
        public IActionResult Edit(UpdateCategoryDto dto)
        {
            try
            {
                _categoryService.Update(dto);
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
