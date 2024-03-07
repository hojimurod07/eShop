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
            User superUser = new()
            {
                Id = 11111111,
                FullName = "Super Admin",
                Phone = "+998908624707",
                Password = PasswordHasher.HashPassword("Super.Admin"),
                Adress = "Database",
                Role = Role.Admin
            };
            modelBuilder.Entity<User>().HasData(superUser);




            base.OnModelCreating(modelBuilder);
        }

        //ready
    }


}
