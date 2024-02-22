using eShop.Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace eShop.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Buscet> Buscets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }


        //ready
    }


}
