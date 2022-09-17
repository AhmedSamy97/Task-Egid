using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StocksApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace StocksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly List<Order> Orders;
        public OrderController()
        {
           Orders = Data.GetOrders();
        }
        [HttpGet]
        public IActionResult GetOrders()
        {
            var list = (from order in Orders
                       join stock in Data.GetStocks() on order.StockId equals stock.Id
                       select new OrderViewModel { 
                           StockName = stock.Name , 
                           Price = order.Price,
                           Commission = order.Commission,
                           Quantity = order.Quantity,
                           PersonName = order.User
                       }).ToList();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult AddOrder(OrderDto order)
        {
            var placedOrder = new Order
            {
                Id = Orders.Count() + 1,
                Price = order.Price,
                Commission = order.Commission,
                Quantity = order.Quantity,
                User = order.User,
                StockId = order.StockId,
            };
            Orders.Add(placedOrder);
            
            return Ok();
        }
    }
}
