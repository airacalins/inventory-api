using Application.Commands.Companies.Dtos;

namespace Application.Commands.Companies.Interfaces
{
    public interface IUpdateCompanyCommand
    {
        Task ExecuteCommand(Guid id, UpdateCompanyDto input);
    }
}