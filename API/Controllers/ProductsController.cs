using API.Controllers.Products.InputModels;
using API.Controllers.Products.ViewModels;
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
        private readonly IGetProductsCommand _getProductsCommand;

        public ProductsController(ICreateProductCommand createProductCommand, IGetProductsCommand getProductsCommand)
        {
            _getProductsCommand = getProductsCommand;
            _createProductCommand = createProductCommand;
        }

        [HttpGet]
        public async Task<List<ProductViewModel>> GetProducts()
        {
            var products = await _getProductsCommand.ExecuteCommand();
            return products.Select(product => new ProductViewModel(product)).ToList();
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] CreateProductInputModel input)
        {
            await _createProductCommand.ExecuteCommand(input.ToDto());
            return Ok();
        }
    }
}