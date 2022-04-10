using MediatR;
using Microsoft.AspNetCore.Mvc;
using SodaCompany.Application.Commands.Products;
using SodaCompany.Application.Queries.Products;
using SodaCompany.Application.Responses.Products;
using SodaCompany.Application.Responses.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SodaCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<PagedResponse<IReadOnlyList<ProductResponse>>>> GetProducts([FromQuery] GetProductsQuery query)
        {
            var products = await _mediator.Send(query);
            if (products.Data.Any())
                return Ok(products);
            return NoContent();
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        public async Task<ActionResult<ProductResponse>> InsertProduct([FromBody] InsertProductCommand command)
        {
            await _mediator.Send(command);
            return Created("", command);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<ProductResponse>> GetProductById([FromRoute] GetProductByIdQuery query)
        {
            var product = await _mediator.Send(query);
            if (product is null)
                return NotFound();
            return Ok(product);
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut("{Id}")]
        public async Task<ActionResult<ProductResponse>> UpdateProduct([FromRoute] Guid Id, [FromBody] UpdateProductCommand command)
        {
            command.Id = Id;
            await _mediator.Send(command);
            return Ok();
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete("{Id}")]
        public async Task<ActionResult<ProductResponse>> DeleteProduct([FromRoute] DeleteProductCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
