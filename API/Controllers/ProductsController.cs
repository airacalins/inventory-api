using API.Controllers.Products.InputModels;
using Application.Commands.Products.Dtos;
using Application.Commands.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductsController : ControllerBase
    {
        private readonly ICreateProductCommand _createProductCommand;

        public ProductsController(ICreateProductCommand createProductCommand)
        {
            _createProductCommand = createProductCommand;
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] CreateProductInputModel input)
        {
            await _createProductCommand.ExecuteCommand(input.ToDto());
            return Ok();
        }
    }
}