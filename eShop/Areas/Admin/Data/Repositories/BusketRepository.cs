using eShop.Areas.Admin.Data;
using eShop.Areas.Admin.Data.Entites;
using eShop.Areas.Admin.Data.interfaces;

namespace eShop.Areas.Admin.Data.Repositories
{
    public class BuscetRepository(AppDbContext db) : Repository<Buscet>(db), IBuscetInterface
    {
    }
}
