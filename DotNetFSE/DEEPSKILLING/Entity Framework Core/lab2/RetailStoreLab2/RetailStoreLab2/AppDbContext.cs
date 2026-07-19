using Microsoft.EntityFrameworkCore;

namespace RetailStoreLab2
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=RetailStoreLab2DB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}