using Microsoft.EntityFrameworkCore;
using ClothingWholesaleAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClothingWholesaleAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Default status values
            modelBuilder.Entity<Order>()
                .Property(o => o.Status)
                .HasConversion<string>();

            // Set default currency - FIXED CODE
            modelBuilder.Entity<Order>()
                .Property(o => o.Currency)
                .HasDefaultValue("'USD'"); // String values need to be wrapped in quotes in SQL
        }
    }
}