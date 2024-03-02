

namespace eShop.Data.Repositories
{
    public class BuscetRepository(AppDbContext db) : Repository<Buscet>(db), IBuscetInterface
    {
    }
}
