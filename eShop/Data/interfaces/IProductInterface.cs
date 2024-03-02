
namespace eShop.Data.interfaces
{
    public interface IProductInterface : IRepository<Product>
    {
        List<Product> GetProductsWithReletions();
    }
}
