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
        private readonly IUpdateCompanyCommand _updateCompanyCommand;
        private readonly IDeleteCompanyCommand _deleteCompanyCommand;

        public CompaniesController(
            ICreateCompanyCommand createCompanyCommand,
            IGetCompaniesCommand getCompaniesCommand,
            IGetCompanyByIdCommand getCompanyByIdCommand,
            IUpdateCompanyCommand updateCompanyCommand,
            IDeleteCompanyCommand deleteCompanyCommand)
        {
            _createCompanyCommand = createCompanyCommand;
            _getCompaniesCommand = getCompaniesCommand;
            _getCompanyByIdCommand = getCompanyByIdCommand;
            _updateCompanyCommand = updateCompanyCommand;
            _deleteCompanyCommand = deleteCompanyCommand;
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

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCompany([FromRoute] Guid id, [FromBody] UpdateCompanyViewModel input)
        {
            await _updateCompanyCommand.ExecuteCommand(id, input.ToDto());
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany([FromRoute] Guid id)
        {
            await _deleteCompanyCommand.ExecuteCommand(id);
            return Ok();
        }
    }
}