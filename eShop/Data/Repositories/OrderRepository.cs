
namespace eShop.Data.Repositories
{
    public class OrderRepository(AppDbContext db) : Repository<Order>(db), IOrderInterface
    {
    }
}
