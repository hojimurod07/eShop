using Microsoft.EntityFrameworkCore;

namespace eShop.Areas.Admin.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Buscet> Buscets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User superUser = new User()
            {
                Id = 1,
                FullName = "Super User",
                Password = "Super.Admin",
                Phone = "+998908624707",
                Adress = "Fergana"

            };
            modelBuilder.Entity<User>().HasData(superUser);




            base.OnModelCreating(modelBuilder);
        }

        //ready
    }


}
