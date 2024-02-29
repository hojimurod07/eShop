using eShop.Data.Entites;

namespace eShop.Data.interfaces
{
    public interface IProductInterface : IRepository<Product>
    {
        List<Product> GetProductsWithReletions();
    }
}
