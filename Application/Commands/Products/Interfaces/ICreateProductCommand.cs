using Application.Commands.Products.Dtos;

namespace Application.Commands.Products.Interfaces
{
    public interface ICreateProductCommand
    {
        Task ExecuteCommand(Guid companyId, CreateProductDto input);
    }
}