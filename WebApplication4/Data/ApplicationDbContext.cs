using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet< Category > Categories{ get; set; }
        public DbSet<Product> products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=. ;Database=kashop-10;Trusted_Connection=True;TrustServerCertificate=True");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
             new Category { Id = 1, Name = "Mobiles" },
             new Category { Id = 2, Name = "Tablets" },
             new Category { Id = 3, Name = "Cameras" },
             new Category { Id = 4, Name = "Accessories" }, 
             new Category { Id = 5, Name = "Laptops" });
        }

    }
}
