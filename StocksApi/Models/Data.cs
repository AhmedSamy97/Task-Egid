using System.Collections.Generic;

namespace StocksApi.Models
{
    class Data
    {
        static List<Stock> Stocks = new List<Stock>()
        {
            new Stock{ Id = 1, Name = "Vianet" , Price = 1},
            new Stock{ Id = 2, Name = "Agritek" , Price = 2},
            new Stock{ Id = 3, Name = "Akamai" , Price = 3},
            new Stock{ Id = 4, Name = "Baidu" , Price = 4},
            new Stock{ Id = 5, Name = "Blinkx" , Price = 5},
            new Stock{ Id = 6, Name = "Blucora" , Price = 6},
            new Stock{ Id = 7, Name = "Boingo" , Price = 7},
            new Stock{ Id = 8, Name = "Brainybrawn" , Price = 8},
            new Stock{ Id = 9, Name = "Carbonite" , Price = 9},
            new Stock{ Id = 10, Name = "China Finance" , Price = 10},
            new Stock{ Id = 11, Name = "ChinaCache" , Price = 11},
            new Stock{ Id = 12, Name = "ADR" , Price = 12},
            new Stock{ Id = 13, Name = "ChitrChatr" , Price = 13},
            new Stock{ Id = 14, Name = "Cnova" , Price = 14},
            new Stock{ Id = 15, Name = "Cogent" , Price = 15},
            new Stock{ Id = 16, Name = "Crexendo" , Price = 16},
            new Stock{ Id = 17, Name = "CrowdGather" , Price = 17},
            new Stock{ Id = 18, Name = "EarthLink" , Price = 18},
            new Stock{ Id = 19, Name = "Eastern" , Price = 19},
            new Stock{ Id = 20, Name = "ENDEXX" , Price = 20},
            new Stock{ Id = 21, Name = "Envestnet" , Price = 21},
            new Stock{ Id = 22, Name = "Epazz" , Price = 22},
            new Stock{ Id = 23, Name = "FlashZero" , Price = 23},
            new Stock{ Id = 24, Name = "Genesis" , Price = 24},
            new Stock{ Id = 25, Name = "InterNAP" , Price = 25},
            new Stock{ Id = 26, Name = "MeetMe" , Price = 26},
            new Stock{ Id = 27, Name = "Netease" , Price = 27},
            new Stock{ Id = 28, Name = "Qihoo" , Price = 28},

        };
        public static List<Stock> GetStocks() => Stocks;
        public static Stock GetStock(int id) => Stocks.Find(x => x.Id == id);
        static List<Order> Orders = new List<Order>()
            {
                new Order() {Id = 1, StockId = 1,User = "Client", Price = 15, Quantity = 20, Commission = .2 },
                new Order() {Id = 2, StockId = 7,User = "Broker", Price = 18, Quantity = 40, Commission = .4 }
        };
        public static List<Order> GetOrders() => Orders;

        public static void AddStocks(Stock stock)
        {
            stock.Id = Stocks.Count + 1;
            Stocks.Add(stock);
        }
        public static void EditStockPrice(Stock stock)
        {
            var existStock = Stocks.Find(x => x.Id == stock.Id);
            if (existStock != null)
            {
                existStock.Price = stock.Price;
            }
        }
    }
}
