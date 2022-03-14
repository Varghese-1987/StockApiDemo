using StockApi.Domain.Entities.StockEnities;

using Microsoft.EntityFrameworkCore;

namespace StockApi.Persistance.EntityConfigurations.StockEntityConfigurations
{
    public static class StockConfigurationHelper
    {
        public static void StockEntityConfigurations(ModelBuilder builder)
        {
            ConfigureStockTable(builder);
            ConfigureStockPriceTable(builder);
        }

        private static void ConfigureStockTable(ModelBuilder builder)
        {
            builder.Entity<Stock>(
                entity=>{
                    entity.ToTable(nameof(Stock));

                    entity.HasKey(stock => stock.Id);

                    entity.Property(stock=>stock.Id).UseIdentityColumn();

                    entity.HasMany(stock => stock.StockPrices)
                       .WithOne(stockPrice => stockPrice.Stock)
                       .HasForeignKey(stock => stock.StockId)
                       .IsRequired()
                       .OnDelete(DeleteBehavior.Cascade);

                    entity.Property(stock => stock.Symbol)
                    .IsRequired()
                    .HasMaxLength(128);

                    entity.HasIndex(stock => stock.Symbol)
                    .HasDatabaseName("IX_Symbol");
    

                    entity.Property(stock => stock.Company)
                    .IsRequired()
                    .HasMaxLength(1024);

                });
        }

        private static void ConfigureStockPriceTable(ModelBuilder builder)
        {
            builder.Entity<StockPrice>(
                entity => {
                    entity.ToTable(nameof(StockPrice));

                    entity.HasIndex(stockPrice => stockPrice.StockId).IsClustered();

                    entity.HasKey(stockPrice => stockPrice.Id).IsClustered(false) ;

                    entity.Property(stockPrice=>stockPrice.Id)
                    .IsRequired()
                    .UseIdentityColumn();

                    entity.Property(stockPrice => stockPrice.Date)
                    .IsRequired();


                    entity.Property(stockPrice => stockPrice.Open)
                    .IsRequired()
                    .HasColumnType("decimal(18,4)");


                    entity.Property(stockPrice => stockPrice.High)
                    .IsRequired()
                    .HasColumnType("decimal(18,4)");


                    entity.Property(stockPrice => stockPrice.Low)
                    .IsRequired()
                    .HasColumnType("decimal(18,4)");

                    entity.Property(stockPrice => stockPrice.Close)
                   .IsRequired()
                   .HasColumnType("decimal(18,4)");


                });
        }
    }
}
