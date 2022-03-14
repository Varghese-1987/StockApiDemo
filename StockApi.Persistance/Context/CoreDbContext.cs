using StockApi.Domain.Entities.StockEnities;
using StockApi.Persistance.EntityConfigurations.StockEntityConfigurations;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace StockApi.Persistance.Context
{
    public class CoreDbContext : IdentityDbContext

    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
        {

          
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockPrice> StockPrices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            StockConfigurationHelper.StockEntityConfigurations(builder);
        }

    }
}
