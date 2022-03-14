using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApi.Domain.Entities.StockEnities
{
    public class Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Company { get; set; }

        public virtual ICollection<StockPrice> StockPrices { get; set; }
    }
}
