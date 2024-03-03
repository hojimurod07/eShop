namespace eShop.Areas.Admin.Data.interfaces
{
    public interface IProductInterface : IRepository<Product>
    {
        List<Product> GetProductsWithReletions();

        Product GetProductWithRelation(int id);
    }
}
