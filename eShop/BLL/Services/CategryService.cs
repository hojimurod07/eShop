using eShop.BLL.Common;
using eShop.BLL.DTOs.CategoryDTOs;
using eShop.BLL.Interfaces;
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
            throw new NotImplementedException();
        }

        public List<CategoryDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public CategoryDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
