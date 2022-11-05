using Application.Commands.Companies.Dtos;
using Application.Commands.Companies.Interfaces;
using Application.Repositories.CompanyRepositories;
using Domain;

namespace Application.Commands.Companies
{
    public class CreateCompanyCommand : ICreateCompanyCommand
    {
        private readonly ICompanyRepository _companyRepository;
        public CreateCompanyCommand(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task ExecuteCommand(CreateCompanyDto input)
        {
            var company = new Company
            {
                ImageUrl = input.ImageUrl,
                Name = input.Name
            };

            _companyRepository.Add(company);
            await _companyRepository.SaveChangesAsync();
        }
    }
}