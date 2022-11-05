using Application.Commands.Companies.Dtos;

namespace Application.Commands.Companies.Interfaces
{
    public interface ICreateCompanyCommand
    {
        Task ExecuteCommand(CreateCompanyDto input);
    }
}