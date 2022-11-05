using Application.Commands.Companies.Dtos;
using Application.Commands.Companies.Interfaces;
using Application.Repositories.CompanyRepositories;

namespace Application.Commands.Companies
{
    public class GetCompanyByIdCommand : IGetCompanyByIdCommand
    {
        private readonly ICompanyRepository _companyRepository;
        public GetCompanyByIdCommand(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task<CompanyDto> ExecuteCommand(Guid id)
        {
            var company = await _companyRepository.Get(id);
            return new CompanyDto(company);
        }
    }
}