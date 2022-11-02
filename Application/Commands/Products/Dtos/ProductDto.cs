using Domain;

namespace Application.Commands.Products.Dtos
{
    public class ProductDto
    {
        public ProductDto(Product item)
        {
            ImageUrl = item.ImageUrl;
            Name = item.Name;
            Stocks = item.Stocks;
            LowStockLevel = item.LowStockLevel;
            Price = item.Price;
            Cost = item.Cost;
        }
        public Guid id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Stocks { get; set; }
        public int LowStockLevel { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }

    }
}