using Application.Commands.Products.Dtos;
using Application.Commands.Products.Interfaces;
using Application.Repositories.ProductRepositories;
using Domain;

namespace Application.Commands.Products
{
    public class CreateProductCommand : ICreateProductCommand
    {
        private readonly IProductRepository _productRepository;
        public CreateProductCommand(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }
        public async Task ExecuteCommand(CreateProductDto input)
        {
            _productRepository.Add(new Product
            {
                ImageUrl = input.ImageUrl,
                Name = input.Name,
                Stocks = input.Stocks,
                LowStockLevel = input.LowStockLevel,
                Price = input.Price,
                Cost = input.Cost,
                DateCreated = DateTime.UtcNow,
            });

            await _productRepository.SaveChangesAsync();
        }
    }
}