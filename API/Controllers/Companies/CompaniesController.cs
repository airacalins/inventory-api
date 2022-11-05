using API.Controllers.Companies.InputModels;
using API.Controllers.Companies.ViewModels;
using Application.Commands.Companies.Dtos;
using Application.Commands.Companies.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Companies
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICreateCompanyCommand _createCompanyCommand;
        private readonly IGetCompaniesCommand _getCompaniesCommand;
        private readonly IGetCompanyByIdCommand _getCompanyByIdCommand;

        public CompaniesController(
            ICreateCompanyCommand createCompanyCommand,
            IGetCompaniesCommand getCompaniesCommand,
            IGetCompanyByIdCommand getCompanyByIdCommand)
        {
            _createCompanyCommand = createCompanyCommand;
            _getCompaniesCommand = getCompaniesCommand;
            _getCompanyByIdCommand = getCompanyByIdCommand;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCompany([FromBody] CreateCompanyViewModel input)
        {
            await _createCompanyCommand.ExecuteCommand(input.ToDto());
            return Ok();
        }

        [HttpGet]
        public async Task<List<CompanyViewModel>> GetCompanies()
        {
            var companies = await _getCompaniesCommand.ExecuteCommand();
            return companies.Select(company => new CompanyViewModel(company)).ToList();
        }

        [HttpGet("{id}")]
        public async Task<CompanyViewModel> GeyCompanyById([FromRoute] Guid id)
        {
            var company = await _getCompanyByIdCommand.ExecuteCommand(id);
            return new CompanyViewModel(company);
        }
    }
}