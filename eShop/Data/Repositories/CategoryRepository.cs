

namespace eShop.Data.Repositories
{
    public class CategoryRepository(AppDbContext db)
        : Repository<Category>(db), ICategoryInterface
    { }
}
