using MediatR;
using System;

namespace SodaCompany.Application.Commands.ProductionPlans
{
    public class UpdateProductionPlanWorkProcedureCommand : IRequest<Unit>
    {
        public Guid OldWorkProcedureId { get; set; }
        public Guid NewWorkProcedureId { get; set; }
        public Guid ProductionPlanId { get; set; }
        public decimal Quantity { get; set; }
    }
}
