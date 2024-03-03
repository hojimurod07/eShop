using eShop.Areas.Admin.Data;
using eShop.Areas.Admin.Data.Entites;
using eShop.Areas.Admin.Data.interfaces;

namespace eShop.Areas.Admin.Data.Repositories
{
    public class OrderRepository(AppDbContext db) : Repository<Order>(db), IOrderInterface
    {
    }
}
