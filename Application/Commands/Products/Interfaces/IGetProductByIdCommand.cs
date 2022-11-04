using Application.Commands.Products.Dtos;

namespace Application.Commands.Products.Interfaces
{
    public interface IGetProductByIdCommand
    {
        Task<ProductDto> ExecuteCommand(Guid id);
    }
}