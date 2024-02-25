using Microsoft.EntityFrameworkCore;
using MyAdsApi.Models;

namespace MyAdsApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<CoinTransaction> CoinTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the entity models (e.g., define primary keys, relationships, etc.)
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Ad>().HasKey(a => a.Id);
            modelBuilder.Entity<CoinTransaction>().HasKey(ct => ct.Id);
        }
    }
}
