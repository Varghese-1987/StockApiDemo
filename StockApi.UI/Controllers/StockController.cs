using StockApi.UI.Contracts;
using StockApi.DataAccess.Services;
using StockApi.DataAccess.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace StockApi.UI.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockService stockService;
        private readonly ILogger<StockController> _logger;
        public StockController(IStockService stockService,ILogger<StockController> logger)
        {
            this.stockService = stockService;
            this._logger = logger;
        }

        [HttpGet(ApiRoutes.StockApiRoutes.GetStock)]
        public IActionResult Get(int stockId)
        {
            _logger.LogInformation("Getting stockId {stockId}",stockId);
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
