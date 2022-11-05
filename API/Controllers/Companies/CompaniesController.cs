using API.Controllers.Companies.InputModels;
using Application.Commands.Companies.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Companies
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICreateCompanyCommand _createCompanyCommand;
        public CompaniesController(ICreateCompanyCommand createCompanyCommand)
        {
            _createCompanyCommand = createCompanyCommand;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCompany([FromBody] CreateCompanyViewModel input)
        {
            await _createCompanyCommand.ExecuteCommand(input.ToDto());
            return Ok();
        }
    }
}