using eShop.Data.Entites;
using eShop.Data.interfaces;

namespace eShop.Data.Repositories
{
    public class ProductRepository(AppDbContext db) : Repository<Product>(db), IProductInterface { }

}
