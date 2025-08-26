using E_Comm.Server.Entities;
using Microsoft.EntityFrameworkCore;


namespace E_Comm.Server.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add custom Fluent API configuration if needed
            modelBuilder.Entity<User>()
             .HasMany<Product>()
             .WithOne(p => p.Seller)
             .HasForeignKey(p => p.SellerId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
