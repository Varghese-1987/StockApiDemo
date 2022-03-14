using StockApi.DataAccess.ViewModels;

namespace StockApi.DataAccess.Services
{
    public interface IStockService
    {
        StockVM GetStockById (int id);

        StockVM CreateStock(StockVM stock);
    }
}
