using MediatR;
using Microsoft.AspNetCore.Mvc;
using SodaCompany.Application.Commands.ProductionPlans;
using SodaCompany.Application.Queries.ProductionPlans;
using SodaCompany.Application.Responses.ProductionPlans;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SodaCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionPlansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductionPlansController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<ProductionPlanResponse>> GetProductionPlans([FromQuery] GetProductionPlansQuery query)
        {
            var productionPlans = await _mediator.Send(query);
            if (productionPlans!=null && productionPlans.Data.Any())
                return Ok(productionPlans);
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<ProductionPlanResponse>> InsertProductionPlan([FromBody] InsertProductionPlanCommand command)
        {
            var createdPlan=await _mediator.Send(command);
            return Created("", createdPlan);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<ProductionPlanResponse>> UpdateProductionPlan([FromBody] UpdateProductionPlanCommand command,[FromRoute] Guid Id)
        {
            command.Id = Id;
            var updatedPlan = await _mediator.Send(command);
            if (updatedPlan is null)
                return NotFound();
            return Ok(updatedPlan);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProductionPlan ([FromRoute] DeleteProductionPlanCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpPost("{productionPlanId}/WorkProcedures")]
        public async Task<ActionResult> InsertProductionPlanWorkProcedure([FromRoute] Guid productionPlanId, [FromBody] InsertProductionPlanWorkProcedureCommand command)
        {
            command.ProductionPlanId = productionPlanId;
            await _mediator.Send(command);
            return Created("", command);
        }
        [HttpPut("{productionPlanId}/WorkProcedures/{workProcedureId}")]
        public async Task<ActionResult> UpdateProductionPlanWorkProcedure([FromRoute] Guid productionPlanId, [FromRoute] Guid workProcedureId, UpdateProductionPlanWorkProcedureCommand command)
        {
            command.ProductionPlanId = productionPlanId;
            command.OldWorkProcedureId = workProcedureId;
            await _mediator.Send(command);
            return Created("", command);
        }
        [HttpDelete("{ProductionPlanId}/WorkProcedures/{WorkProcedureId}")]
        public async Task<ActionResult> DeleteProductionPlanWorkProcedure([FromRoute] DeleteProductionPlanWorkProcedureCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpGet("ProductionOrder/{ProductionOrderId}")]
        public async Task<ActionResult<ProductionPlanResponse>> GetProductionPlanByProductionOrderId([FromRoute] GetProductionPlanByProductionOrderIdQuery query)
        {
            var productionPlan = await _mediator.Send(query);
            if (productionPlan is null)
                return NotFound();
            return Ok(productionPlan);
        }
    }
}
