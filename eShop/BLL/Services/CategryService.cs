using eShop.BLL.Common;
using eShop.BLL.DTOs.CategoryDTOs;
using eShop.BLL.Interfaces;
using eShop.Data.Entites;
using eShop.Data.interfaces;

namespace eShop.BLL.Services
{
    public class CategryService(IUnitOfWork unitOfWork) : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public void Create(AddCategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                throw new ArgumentNullException("Category was null");

            }
            if (string.IsNullOrEmpty(categoryDto.Name))
            {
                throw new CustomExeption("Category name is Required");
            }
            if (categoryDto.Name.Length < 3 || categoryDto.Name.Length > 50)
            {
                throw new CustomExeption("Name must be between 3 and 30 characters");
            }

        }

        public void Delete(int id)
        {
            var category = _unitOfWork.Categories.GetById(id);
            if (category == null)
            {
                throw new CustomExeption("Category was not found");
            }
            _unitOfWork.Categories.Delete(category.Id);
        }

        public List<CategoryDto> GetAll()
        {
            var categories = _unitOfWork.Categories.GetAll();
            var list = categories.Select(c => new CategoryDto()
            {
                Id = c.Id,
                Name = c.Name,

            }

            ).ToList();
            return list;

        }

        public CategoryDto GetById(int id)
        {
            var category = _unitOfWork.Categories.GetById(id);
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            return new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name

            };
        }

        public void Update(CategoryDto categoryDto)
        {
            var category = _unitOfWork.Categories.GetById(categoryDto.Id);
            if (category == null)
            {
                throw new Exception("Categry not found");

            }
            if (string.IsNullOrEmpty(categoryDto.Name))
            {
                throw new CustomExeption("Category name is Required");
            }
            if (categoryDto.Name.Length < 3 || categoryDto.Name.Length > 50)
            {
                throw new CustomExeption("Name must be between 3 and 30 characters");
            }
            var categoryUpdate = new Category()
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,

            };
            _unitOfWork.Categories.Update(categoryUpdate);


        }
    }
}
