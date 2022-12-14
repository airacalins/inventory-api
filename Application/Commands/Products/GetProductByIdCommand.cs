using Application.Commands.Products.Dtos;
using Application.Commands.Products.Interfaces;
using Application.Repositories.ProductRepositories;

namespace Application.Commands.Products
{
    public class GetProductByIdCommand : IGetProductByIdCommand
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdCommand(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }
        public async Task<ProductDto> ExecuteCommand(Guid companyId, Guid productId)
        {
            var product = await _productRepository.GetCompanyProductById(companyId, productId);
            return new ProductDto(product);
        }
    }
}