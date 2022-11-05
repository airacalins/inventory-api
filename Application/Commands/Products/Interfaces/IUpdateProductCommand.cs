using Application.Commands.Products.Dtos;

namespace Application.Commands.Products.Interfaces
{
    public interface IUpdateProductCommand
    {
        Task ExecuteCommand(Guid id, UpdateProductDto input);
    }
}