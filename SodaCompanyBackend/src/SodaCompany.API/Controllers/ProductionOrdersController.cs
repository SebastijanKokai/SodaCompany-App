using MediatR;
using Microsoft.AspNetCore.Mvc;
using SodaCompany.Application.Commands.ProductionOrders;
using SodaCompany.Application.Queries.ProductionOrders;
using SodaCompany.Application.Responses.ProductionOrders;
using SodaCompany.Application.Responses.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SodaCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionOrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductionOrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<PagedResponse<IReadOnlyList<ProductionOrderResponse>>>> GetProductionOrders([FromQuery] GetProductionOrderQuery query)
        {
            var productionOrders = await _mediator.Send(query);
            if (productionOrders.Data.Any())
                return Ok(productionOrders);
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult> InsertProductionOrder([FromBody] InsertProductionOrderCommand command)
        {
            await _mediator.Send(command);
            return Created("", command);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<ProductionOrderResponse>> GetProductionOrderById([FromRoute] GetProductionOrderByIdQuery query)
        {
            var productionOrders = await _mediator.Send(query);
            if (productionOrders is null)
                return NotFound();
            return Ok(productionOrders);
        }
        [HttpPost("{orderId}/Products")]
        public async Task<ActionResult> InsertOrderedProduct([FromRoute] Guid orderId, [FromBody] InsertOrderProductCommand command)
        {
            command.OrderId = orderId;
            await _mediator.Send(command);
            return Created("", command);
        }
        [HttpPut("{orderId}/Products/{productId}")]
        public async Task<ActionResult> InsertOrderedProduct([FromRoute] Guid orderId, [FromRoute] Guid productId, UpdateOrderProductCommand command)
        {
            command.OrderId = orderId;
            command.OldProductId = productId;
            await _mediator.Send(command);
            return Created("", command);
        }
        [HttpDelete("{OrderId}/Products/{ProductId}")]
        public async Task<ActionResult> DeleteProductOrder([FromRoute] DeleteOrderProductCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
