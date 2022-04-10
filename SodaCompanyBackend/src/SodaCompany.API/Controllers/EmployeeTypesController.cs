using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SodaCompany.Application.Commands.EmployeeType;
using SodaCompany.Application.Queries.EmployeeTypes;
using SodaCompany.Application.Responses.EmployeeTypes;
using SodaCompany.Application.Responses.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SodaCompany.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<PagedResponse<IReadOnlyList<EmployeeTypeResponse>>>> GetProducts([FromQuery] GetEmployeeTypesQuery query)
        {
            var employeeTypes = await _mediator.Send(query);
            if (employeeTypes.Data.Any())
                return Ok(employeeTypes);
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<EmployeeTypeResponse>> InsertProduct([FromBody] InsertEmployeeTypeCommand command)
        {
            await _mediator.Send(command);
            return Created("", command);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<EmployeeTypeResponse>> GetProductById([FromRoute] GetEmployeeTypeByIdQuery query)
        {
            var product = await _mediator.Send(query);
            if (product is null)
                return NotFound();
            return Ok(product);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<EmployeeTypeResponse>> UpdateProduct([FromRoute] Guid Id, [FromBody] UpdateEmployeeTypeCommand command)
        {
            command.Id = Id;
            await _mediator.Send(command);
            return Ok();
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<EmployeeTypeResponse>> DeleteProduct([FromRoute] DeleteEmployeeTypeCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
