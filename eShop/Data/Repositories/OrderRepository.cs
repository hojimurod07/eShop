using eShop.Data.Entites;
using eShop.Data.interfaces;

namespace eShop.Data.Repositories
{
    public class OrderRepository(AppDbContext db) : Repository<Order>(db), IOrderInterface
    {
    }
}
