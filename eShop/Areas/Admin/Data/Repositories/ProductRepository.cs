using eShop.Areas.Admin.Data;
using eShop.Areas.Admin.Data.Entites;
using eShop.Areas.Admin.Data.interfaces;
using Microsoft.EntityFrameworkCore;

namespace eShop.Areas.Admin.Data.Repositories
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
