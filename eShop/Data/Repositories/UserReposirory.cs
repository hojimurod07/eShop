using eShop.Data.Entites;
using eShop.Data.interfaces;

namespace eShop.Data.Repositories
{
    public class UserReposirory(AppDbContext db) : Repository<User>(db), IUserInterface
    {
    }
}
