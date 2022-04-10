using MediatR;
using System;

namespace SodaCompany.Application.Commands.ProductionPlans
{
    public class InsertProductionPlanWorkProcedureCommand : IRequest<Unit>
    {
        public Guid WorkProcedureId { get; set; }
        public Guid ProductionPlanId { get; set; }
        public decimal Quantity { get; set; }
    }
}
