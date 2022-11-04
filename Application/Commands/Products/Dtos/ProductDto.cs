using Domain;

namespace Application.Commands.Products.Dtos
{
    public class ProductDto
    {
        public ProductDto(Product product)
        {
            Id = product.Id;
            ImageUrl = product.ImageUrl;
            Name = product.Name;
            Stocks = product.Stocks;
            LowStockLevel = product.LowStockLevel;
            Price = product.Price;
            Cost = product.Cost;
            DateCreated = product.DateCreated;
        }
        public Guid Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Stocks { get; set; }
        public int LowStockLevel { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }
        public DateTime DateCreated { get; set; }

    }
}