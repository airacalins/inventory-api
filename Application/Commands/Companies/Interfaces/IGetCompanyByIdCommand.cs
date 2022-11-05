using Application.Commands.Companies.Dtos;

namespace Application.Commands.Companies.Interfaces
{
    public interface IGetCompanyByIdCommand
    {
        Task<CompanyDto> ExecuteCommand(Guid id);
    }
}