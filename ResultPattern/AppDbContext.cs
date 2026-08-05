using Microsoft.EntityFrameworkCore;
using ResultPattern.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResultPattern
{
    public class AppDbContext :DbContext
    {
        public DbSet<User> users { get; set; }
        public AppDbContext()
        { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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
