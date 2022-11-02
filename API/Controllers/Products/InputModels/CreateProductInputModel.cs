using Application.Commands.Products.Dtos;

namespace API.Controllers.Products.InputModels
{
    public class CreateProductInputModel
    {
        public string ImageUrl { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Stocks { get; set; }
        public int LowStockLevel { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }

        public CreateProductDto ToDto()
        {
            return new CreateProductDto
            {
                ImageUrl = ImageUrl,
                Name = Name,
                Stocks = Stocks,
                LowStockLevel = LowStockLevel,
                Price = Price,
                Cost = Cost
            };
        }
    }
}