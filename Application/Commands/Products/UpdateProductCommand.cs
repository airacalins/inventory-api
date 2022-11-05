using Application.Commands.Products.Dtos;
using Application.Commands.Products.Interfaces;
using Application.Repositories.ProductRepositories;
using Domain;

namespace Application.Commands.Products
{
    public class UpdateProductCommand : IUpdateProductCommand
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommand(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task ExecuteCommand(Guid id, UpdateProductDto input)
        {
            var product = await _productRepository.Get(id);
            product.ImageUrl = input.ImageUrl;
            product.Name = input.Name;
            product.Stocks = input.Stocks;
            product.LowStockLevel = input.LowStockLevel;
            product.Price = input.Price;
            product.Cost = input.Cost;

            await _productRepository.Update(id, product);
            await _productRepository.SaveChangesAsync();
        }
    }
}