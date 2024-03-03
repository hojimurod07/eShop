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

        public Product GetProductWithRelation(int id)
        {
            return _db.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
        }
    }

}
