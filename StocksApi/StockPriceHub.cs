using Microsoft.AspNetCore.SignalR;
using StocksApi.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StocksApi
{
    public class StockPriceHub: Hub
    {
        public async Task Streaming(CancellationToken cancellationToken)
        {
            while (true)
            {
                Random rng = new Random();

                foreach (var stock in Data.GetStocks())
                {
                    stock.Price = rng.Next(1,100);
                }

                if (Clients != null)
                {
                    await Clients.All.SendAsync("ReceiveMessage", Data.GetStocks());
                }
                await Task.Delay(10000, cancellationToken);

            }
        }
        public async Task SendPrice(Stock stock)
        {
            //Send to All Clients new price
            if (Clients != null)
            {
                await Clients.All.SendAsync("ReceiveMessage", stock);

            }
        }
    }
}
