using Application.Commands.Products.Dtos;

namespace API.Controllers.Products.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel(ProductDto item)
        {
            Id = item.Id;
            ImageUrl = item.ImageUrl;
            Name = item.Name;
            Stocks = item.Stocks;
            LowStockLevel = item.LowStockLevel;
            Price = item.Price;
            Cost = item.Cost;
        }
        public Guid Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Stocks { get; set; }
        public int LowStockLevel { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }
    }
}