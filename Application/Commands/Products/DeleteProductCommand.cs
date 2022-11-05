using Application.Commands.Products.Interfaces;
using Application.Repositories.ProductRepositories;

namespace Application.Commands.Products
{
    public class DeleteProductCommand : IDeleteProductCommand
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductCommand(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task ExecuteCommand(Guid id)
        {
            await _productRepository.Delete(id);
            await _productRepository.SaveChangesAsync();
        }
    }
}