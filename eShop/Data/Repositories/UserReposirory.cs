
namespace eShop.Data.Repositories
{
    public class UserReposirory(AppDbContext db) : Repository<User>(db), IUserInterface
    {
    }
}
