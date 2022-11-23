

namespace Market.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(MarketDbContext context)
        {
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
