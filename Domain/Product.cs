using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Stocks { get; set; }
        public int LowStockLevel { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }
        public DateTime DateCreated { get; set; }
    }
}