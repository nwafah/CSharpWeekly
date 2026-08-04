using Microsoft.EntityFrameworkCore;

namespace EFCoreConcurrency
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Product>()
               .Property(p => p.RowVersion)
                .IsRowVersion();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=CSharpWeekly;User ID=sa;Password=Sql@2026StrongPass!;Trust Server Certificate=True");
            }
        }
    }
}
