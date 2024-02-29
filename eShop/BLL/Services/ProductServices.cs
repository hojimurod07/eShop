using eShop.BLL.Common;
using eShop.BLL.DTOs.ProductDTOs;
using eShop.BLL.Interfaces;
using eShop.Data.Entites;
using eShop.Data.interfaces;

namespace eShop.BLL.Services
{
    public class ProductServices(IUnitOfWork unitofWork,
                                   IUploadService uploadService) : IProductService
    {
        private readonly IUnitOfWork _unitofWork = unitofWork;
        private readonly IUploadService _uploadService = uploadService;

        public void Create(AddProductDto product)
        {
            if (product == null) throw new ArgumentNullException("product was null");
            if (string.IsNullOrEmpty(product.Name)) throw new ArgumentNullException("name is reqiuired");
            if (product.Name.Length < 3 || product.Name.Length > 50) throw new CustomExeption("Name must be between in 3 and 30 characters");
            if (product.Image == null) throw new CustomExeption("Image is required");



            Product productEntity = new Product()
            {
                Name = product.Name,
                ImageUrl = _uploadService.UploadImage(product.Image),
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                Category = null
            };
            _unitofWork.Products.Add(productEntity);
        }

        public void Delete(int id)
        {
            var product = _unitofWork.Products.GetById(id);
            if (product == null)
            {
                throw new CustomExeption("Product was not found");

            }
            _uploadService.DeleteImage(product.ImageUrl);
            _unitofWork.Products.Delete(product.Id);
        }

        public List<ProductDto> GetAll()
        {
            var products = _unitofWork.Products.GetProductsWithReletions();

            var list = products.Select(p => p.ToProductDto()).ToList();
            return list;

        }

        public ProductDto GetById(int id)
        {
            var product = _unitofWork.Products.GetById(id);
            //if (product == null) throw new CustomExeption("Car not found");
            return product.ToProductDto();


        }

        public void Update(UpdateProductDto product)
        {
            var prod = _unitofWork.Products.GetById(product.Id);
            if (prod == null) throw new CustomExeption("Product not found");
            if (product == null) throw new ArgumentNullException("product was null");
            if (string.IsNullOrEmpty(product.Name)) throw new ArgumentNullException("name is reqiuired");
            if (product.Name.Length < 3 || product.Name.Length > 50) throw new CustomExeption("Name must be between in 3 and 30 characters");
            if (product.file != null)
            {
                _uploadService.DeleteImage(prod.ImageUrl);
                prod.ImageUrl = _uploadService.UploadImage(product.file);
            }
            else
            {
                prod.ImageUrl = product.ImageUrl;
            }
            prod.Name = product.Name;
            prod.Description = product.Description;
            prod.Price = product.Price;
            prod.CategoryId = product.Category.Id;
            _unitofWork.Products.Update(prod);

        }
    }
}
