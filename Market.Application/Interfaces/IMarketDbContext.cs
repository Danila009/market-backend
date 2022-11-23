using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Market.Domain.User;
using Market.Domain.Product;
using Market.Domain.Product.Filters;
using Market.Domain;

namespace Market.Application.Interfaces
{
    public interface IMarketDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<AdminUser> AdminUsers { get; set; }
        DbSet<Domain.Product.Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Domain.Shop.Shop> Shops { get; set; }
        DbSet<Domain.City> Cities { get; set; }
        DbSet<Domain.Country> Countries { get; set; }
        DbSet<Image> Image { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
