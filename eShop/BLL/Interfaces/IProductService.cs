namespace eShop.BLL.Interfaces
{
    public interface IProductService
    {
        List<ProductDto> GetAll();
        ProductDto GetById(int id);
        void Create(AddProductDto product);
        void Update(UpdateProductDto product);
        void Delete(int id);
        ProductDto GetByIdWithRelations(int id);

    }
}
