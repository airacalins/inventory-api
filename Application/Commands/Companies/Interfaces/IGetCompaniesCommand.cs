using Application.Commands.Companies.Dtos;

namespace Application.Commands.Companies.Interfaces
{
    public interface IGetCompaniesCommand
    {
        Task<List<CompanyDto>> ExecuteCommand();
    }
}