using eShop.Data.Entites;
using eShop.Data.interfaces;
using Microsoft.EntityFrameworkCore;

namespace eShop.Data.Repositories
{
    public class ProductRepository(AppDbContext db) : Repository<Product>(db), IProductInterface
    {
        AppDbContext _db = db;
        public List<Product> GetProductsWithReletions()
        {
            return _db.Products.Include(c => c.Category).ToList();
        }
    }

}
