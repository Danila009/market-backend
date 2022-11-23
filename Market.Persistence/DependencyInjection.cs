using Market.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Market.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services)
        {
            services.MySqlConnection();

            services.AddScoped<IMarketDbContext>(provider => 
                provider.GetService<MarketDbContext>());

            return services;
        }
    }
}
