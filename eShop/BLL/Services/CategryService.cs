using eShop.BLL.Common;
using eShop.BLL.DTOs.CategoryDTOs;
using eShop.BLL.Interfaces;
using eShop.Data.Entites;
using eShop.Data.interfaces;

namespace eShop.BLL.Services
{
    public class CategryService(IUnitOfWork unitOfWork,
                                IUploadService uploadfile) : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IUploadService _uploadfile = uploadfile;

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
            if (categoryDto.file == null)
            {
                throw new CustomExeption("Category image is required");
            }
            Category category = new Category()
            {
                Name = categoryDto.Name,
                ImageUrl = _uploadfile.UploadImage(categoryDto.file),

            };
            _unitOfWork.Categories.Add(category);


        }

        public void Delete(int id)
        {
            var category = _unitOfWork.Categories.GetById(id);
            if (category == null)
            {
                throw new CustomExeption("Category was not found");
            }
            _uploadfile.DeleteImage(category.ImageUrl);
            _unitOfWork.Categories.Delete(category.Id);
        }

        public List<CategoryDto> GetAll()
        {
            var categories = _unitOfWork.Categories.GetAll();
            var list = categories.Select(c => new CategoryDto()
            {
                Id = c.Id,
                Name = c.Name,
                ImagePath = c.ImageUrl

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
                Name = category.Name,
                ImagePath = category.ImageUrl


            };
        }

        public void Update(UpdateCategoryDto categoryDto)
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
            if (categoryDto.file != null)
            {
                _uploadfile.DeleteImage(category.ImageUrl);
                category.ImageUrl = _uploadfile.UploadImage(categoryDto.file);
            }
            else
            {

                category.ImageUrl = categoryDto.ImagePath;
            }
            category.Name = categoryDto.Name;

            _unitOfWork.Categories.Update(category);


        }
    }
}
