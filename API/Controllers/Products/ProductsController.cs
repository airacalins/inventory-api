using API.Controllers.Products.InputModels;
using API.Controllers.Products.ViewModels;
using Application.Commands.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Products
{
    [ApiController]
    [Route("api/company/{companyId}/[controller]")]

    public class ProductsController : ControllerBase
    {
        private readonly ICreateProductCommand _createProductCommand;
        private readonly IGetProductsCommand _getProductsCommand;
        private readonly IGetProductByIdCommand _getProductByIdCommand;
        private readonly IUpdateProductCommand _updateProductCommand;
        private readonly IDeleteProductCommand _deleteProductCommand;

        public ProductsController(
            ICreateProductCommand createProductCommand,
            IGetProductsCommand getProductsCommand,
            IGetProductByIdCommand getProductByIdCommand,
            IUpdateProductCommand updateProductCommand,
            IDeleteProductCommand deleteProductCommand)
        {
            _createProductCommand = createProductCommand;
            _getProductsCommand = getProductsCommand;
            _getProductByIdCommand = getProductByIdCommand;
            _updateProductCommand = updateProductCommand;
            _deleteProductCommand = deleteProductCommand;
        }

        [HttpGet]
        public async Task<List<ProductViewModel>> GetProducts([FromRoute] Guid companyId)
        {
            var products = await _getProductsCommand.ExecuteCommand(companyId);
            return products.Select(product => new ProductViewModel(product)).ToList();
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromRoute] Guid companyId, [FromBody] CreateProductInputModel input)
        {
            await _createProductCommand.ExecuteCommand(companyId, input.ToDto());
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> GetProductById([FromRoute] Guid companyId, [FromRoute] Guid productId)
        {
            var product = await _getProductByIdCommand.ExecuteCommand(companyId, productId);
            return new ProductViewModel(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductViewModel input)
        {
            await _updateProductCommand.ExecuteCommand(id, input.ToDto());
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct([FromRoute] Guid id)
        {
            await _deleteProductCommand.ExecuteCommand(id);
            return Ok();
        }
    }
}