using eShop.Data.Entites;
using eShop.Data.interfaces;

namespace eShop.Data.Repositories
{
    public class BuscetRepository(AppDbContext db) : Repository<Buscet>(db), IBuscetInterface
    {
    }
}
