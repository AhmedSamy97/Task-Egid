using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using StocksApi.Models;
using System.Threading.Tasks;

namespace StocksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly StockPriceHub _hub;
        private static bool flag = false;
        public StockController(StockPriceHub hub)
        {
            _hub = hub;
            if (!flag)
            {
                startStreamPrice().GetAwaiter();
                flag = true;
            }
        }

        [HttpGet]
        public IActionResult GetAllStock()
        {
            return Ok(Data.GetStocks());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetStock(int id)
        {
            return Ok(Data.GetStock(id));
        }

        async Task startStreamPrice()
        {
            await _hub.Streaming(System.Threading.CancellationToken.None);
        }

    }
}
