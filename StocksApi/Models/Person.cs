using System.Collections.Generic;

namespace StocksApi.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
    }
}
