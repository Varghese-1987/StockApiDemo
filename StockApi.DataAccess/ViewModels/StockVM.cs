using StockApi.Domain.Entities.StockEnities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApi.DataAccess.ViewModels
{
    public class StockVM
    {

        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Company { get; set; }

        public StockVM()
        {

        }
        public StockVM(Stock stock)
        {
            this.Id = stock.Id;
            this.Symbol = stock.Symbol;
            this.Company = stock.Company;
        }
    }
}
