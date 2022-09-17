namespace StocksApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Commission { get; set; }
        public string User { get; set; }
    }
}
