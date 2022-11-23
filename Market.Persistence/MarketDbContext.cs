using Microsoft.EntityFrameworkCore;
using Market.Application.Interfaces;
using Market.Domain;
using Market.Persistence.EntityTypeConfiguration;
using Market.Domain.User;
using Market.Domain.Product;
using Market.Domain.Product.Filters;
using Market.Domain.Shop;

namespace Market.Persistence
{
    public class MarketDbContext : DbContext, IMarketDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Image> Image { get; set; }

        public MarketDbContext(DbContextOptions<MarketDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ShopConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
