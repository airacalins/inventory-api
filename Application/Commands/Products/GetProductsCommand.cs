using Application.Commands.Products.Dtos;
using Application.Commands.Products.Interfaces;
using Application.Repositories.ProductRepositories;

namespace Application.Commands.Products
{
    public class GetProductsCommand : IGetProductsCommand
    {
        private readonly IProductRepository _productRepository;
        public GetProductsCommand(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }
        public async Task<List<ProductDto>> ExecuteCommand(Guid companyId)
        {
            var products = await _productRepository.GetAllByCompanyId(companyId);
            return products.Select(product => new ProductDto(product)).ToList();
        }
    }
}