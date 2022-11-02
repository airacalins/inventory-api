using Application.Commands.Products.Dtos;

namespace Application.Commands.Products.Interfaces
{
    public interface IGetProductsCommand
    {
        Task<List<ProductDto>> ExecuteCommand();
    }
}