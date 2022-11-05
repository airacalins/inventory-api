using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Companies.Dtos;
using Application.Commands.Companies.Interfaces;
using Application.Repositories.CompanyRepositories;

namespace Application.Commands.Companies
{
    public class GetCompaniesCommand : IGetCompaniesCommand
    {
        private readonly ICompanyRepository _companyRepository;

        public GetCompaniesCommand(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task<List<CompanyDto>> ExecuteCommand()
        {
            var companies = await _companyRepository.GetAll();
            return companies.Select(company => new CompanyDto(company)).ToList();
        }
    }
}