using eShop.Data.interfaces;

namespace eShop.Data.Repositories
{
    public class UnitOfWork(AppDbContext db) : IUnitOfWork
    {
        public IBuscetInterface Buscets => new BuscetRepository(db);

        public ICategoryInterface Categories => new CategoryRepository(db);

        public IOrderInterface Orders => new OrderRepository(db);

        public IProductInterface Products => new ProductRepository(db);

        public IUserInterface Users => new UserReposirory(db);
    }
}
