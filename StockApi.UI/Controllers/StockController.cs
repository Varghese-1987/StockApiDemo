using StockApi.UI.Contracts;
using StockApi.DataAccess.Services;
using StockApi.DataAccess.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace StockApi.UI.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockService stockService;
        public StockController(IStockService stockService)
        {
            this.stockService = stockService;
        }

        [HttpGet(ApiRoutes.StockApiRoutes.GetStock)]
        public IActionResult Get(int stockId)
        {
            var stock=stockService.GetStockById(stockId);

            return Ok(stock);
        }

        [HttpPost(ApiRoutes.StockApiRoutes.CreateStock)]
        public IActionResult Create([Bind("Symbol","Company")] StockVM stockVM)
        {
            var stock = stockService.CreateStock(stockVM);

            return Ok(stock);
        }
    }
}
