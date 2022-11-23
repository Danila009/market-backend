using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;

namespace Market.Persistence
{
    public static class DbConnection
    {
        public static IServiceCollection MySqlConnection(this IServiceCollection services)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "cfif31.ru";
            builder.Port = 3306;
            builder.UserID = "ISPr24-39_BeluakovDS";
            builder.Password = "ISPr24-39_BeluakovDS";
            builder.Database = "ISPr24-39_BeluakovDS_Market";
            builder.CharacterSet = "utf8";

            services.AddDbContext<MarketDbContext>(options =>
            {
                options.UseMySql(builder.ConnectionString,
                    ServerVersion.AutoDetect(builder.ConnectionString));
            });

            return services;
        }
    }
}
