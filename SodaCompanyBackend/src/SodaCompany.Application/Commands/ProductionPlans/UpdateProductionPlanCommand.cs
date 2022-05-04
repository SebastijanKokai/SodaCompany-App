using MediatR;
using SodaCompany.Application.Dtos;
using SodaCompany.Application.Responses.ProductionPlans;
using System;
using System.Collections.Generic;
using System.Text;

namespace SodaCompany.Application.Commands.ProductionPlans
{
    public class UpdateProductionPlanCommand : IRequest<ProductionPlanResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime ProductionDeadline { get; set; }
        public Guid ProductionOrderId { get; set; }
        public List<ProductionPlanWorkProcedureDto> PlanWorkProcedures { get; set; }
    }
}
