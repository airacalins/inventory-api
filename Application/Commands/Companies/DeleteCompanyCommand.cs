using Application.Commands.Companies.Interfaces;
using Application.Repositories.CompanyRepositories;

namespace Application.Commands.Companies
{
    public class DeleteCompanyCommand : IDeleteCompanyCommand
    {
        private readonly ICompanyRepository _companyRepository;

        public DeleteCompanyCommand(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task ExecuteCommand(Guid id)
        {
            await _companyRepository.Delete(id);
            await _companyRepository.SaveChangesAsync();
        }
    }
}