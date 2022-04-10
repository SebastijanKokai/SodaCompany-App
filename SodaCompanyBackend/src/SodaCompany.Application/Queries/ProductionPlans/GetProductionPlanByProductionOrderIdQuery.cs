using MediatR;
using SodaCompany.Application.Responses.ProductionPlans;
using System;

namespace SodaCompany.Application.Queries.ProductionPlans
{
    public class GetProductionPlanByProductionOrderIdQuery : IRequest<ProductionPlanResponse>
    {
        public Guid ProductionOrderId { get; set; }
    }
}
