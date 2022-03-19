using StockApi.DataAccess.Services;
using StockApi.DataAccess.ViewModels;
using StockApi.UI.Controllers;

using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Xunit;

namespace StockApi.UnitTests
{
    public class StockControllerTest
    {
        private readonly StockController _stockController;
        private readonly Mock<IStockService> _stockService;
        private readonly Mock<ILogger<StockController>> _logger;

        public StockControllerTest()
        {
            _stockService = new Mock<IStockService>();
            _logger = new Mock<ILogger<StockController>>();
            _stockController = new StockController(_stockService.Object, _logger.Object);
        }

        [Fact]
        public void Get_Stock_Test()
        {
            var ok = _stockController.Get(1);
            Assert.IsType<Task<IActionResult>>(ok as Task<IActionResult>);
        }

        [Fact]
        public void Create_Stock_Test()
        {
            var stock = new StockVM()
            {
                Company="Demo",
                Symbol="DM",
                Id=0
            };
            var createdStock = _stockController.Create(stock);
            Assert.IsType<Task<IActionResult>>(createdStock as Task<IActionResult>);
        }
    }
}
