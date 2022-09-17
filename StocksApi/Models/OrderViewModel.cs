using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksApi.Models
{
    public class OrderViewModel
    {
        public string PersonName { get; set; }
        public string StockName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Commission { get; set; }

    }
}
