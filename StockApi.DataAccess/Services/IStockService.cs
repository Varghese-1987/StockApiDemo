using StockApi.DataAccess.ViewModels;

namespace StockApi.DataAccess.Services
{
    public interface IStockService
    {
        Task<StockVM> GetStockById (int id);

        Task<StockVM> CreateStock(StockVM stock);
    }
}
