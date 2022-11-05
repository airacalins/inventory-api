using Application.Commands.Companies.Dtos;
using Application.Commands.Companies.Interfaces;
using Application.Repositories.CompanyRepositories;

namespace Application.Commands.Companies
{
    public class UpdateCompanyCommand : IUpdateCompanyCommand
    {
        private readonly ICompanyRepository _companyRepository;
        public UpdateCompanyCommand(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task ExecuteCommand(Guid id, UpdateCompanyDto input)
        {
            var company = await _companyRepository.Get(id);

            company.ImageUrl = input.ImageUrl;
            company.Name = input.Name;

            await _companyRepository.Update(id, company);
            await _companyRepository.SaveChangesAsync();
        }
    }
}