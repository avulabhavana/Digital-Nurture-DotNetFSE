using Microsoft.EntityFrameworkCore;

namespace RetailDataRetrieveLab5
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=RetailDataRetrieveLab5DB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}