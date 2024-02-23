using eShop.Data.Entites;
using eShop.Data.interfaces;

namespace eShop.Data.Repositories
{
    public class CategoryRepository(AppDbContext db)
        : Repository<Category>(db), ICategoryInterface
    { }
}
