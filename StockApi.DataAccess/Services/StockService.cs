using StockApi.DataAccess.ViewModels;
using StockApi.Domain.Entities.StockEnities;
using StockApi.Persistance.Context;

using Microsoft.EntityFrameworkCore;


namespace StockApi.DataAccess.Services
{
    public class StockService : IStockService
    {
        private readonly CoreDbContext _coreDbCOntext;

        public StockService(CoreDbContext coreDbContext)
        {
            this._coreDbCOntext = coreDbContext;
        }
        public async Task<StockVM> CreateStock(StockVM stockVM)
        {
            var stock = new Stock();

            int createdStockId = 0;

            stock.Symbol = stockVM.Symbol;
            stock.Company = stockVM.Company;
            _coreDbCOntext.Stocks.Add(stock);
            createdStockId = await _coreDbCOntext.SaveChangesAsync();

            stock =await _coreDbCOntext.Stocks.FirstOrDefaultAsync(x => x.Id == stock.Id);

            if (createdStockId > 0 &&stock !=null)
            {
                return new StockVM(stock);
            }
            return new StockVM();
        }

        public async  Task<StockVM> GetStockById(int id)
        {
            Stock? stock = await _coreDbCOntext.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if(stock != null)
            {
                return new StockVM(stock);
            }
            return new StockVM();
        }
    }
}
