using MediatR;
using System;

namespace SodaCompany.Application.Commands.ProductionPlans
{
    public class DeleteProductionPlanWorkProcedureCommand : IRequest<Unit>
    {
        public Guid ProductionPlanId { get; set; }
        public Guid WorkProcedureId { get; set; }
    }
}
