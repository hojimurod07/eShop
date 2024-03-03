using eShop.Areas.Admin.BLL.DTOs.ProductDTOs;

namespace eShop.Areas.Admin.BLL.Interfaces
{
    public interface IProductService
    {
        List<ProductDto> GetAll();
        ProductDto GetById(int id);
        void Create(AddProductDto product);
        void Update(UpdateProductDto product);
        void Delete(int id);

    }
}
