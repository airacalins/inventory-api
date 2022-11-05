namespace Application.Commands.Products.Interfaces
{
    public interface IDeleteProductCommand
    {
        Task ExecuteCommand(Guid id);
    }
}