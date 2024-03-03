using eShop.Areas.Admin.Data.Entites;

namespace eShop.Areas.Admin.Data.interfaces
{
    public interface IProductInterface : IRepository<Product>
    {
        List<Product> GetProductsWithReletions();
    }
}
