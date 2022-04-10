using MediatR;
using SodaCompany.Application.Commands.ProductionPlans;
using SodaCompany.Application.Mappers;
using SodaCompany.Core.Entities;
using SodaCompany.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.CommandHandlers.ProductionPlans
{
    public class InsertProductionPlanHandler : IRequestHandler<InsertProductionPlanCommand, Unit>
    {
        private readonly IProductionPlanRepository _productionPlanRepository;

        public InsertProductionPlanHandler(IProductionPlanRepository productionPlanRepository)
        {
            _productionPlanRepository = productionPlanRepository;
        }
        public async Task<Unit> Handle(InsertProductionPlanCommand request, CancellationToken cancellationToken)
        {
            var newPlan = ProductionPlanMapper.Mapper.Map<ProductionPlan>(request);
            var planWorkProcedures = ProductionPlanMapper.Mapper.Map<List<ProductionPlanWorkProcedure>>(request.PlanWorkProcedures).Select(product =>
            {
                product.ProductionPlanId = newPlan.Id;
                return product;
            }).ToList();
            newPlan.ProductionPlanWorkProcedure = planWorkProcedures;
            var createdOrder = await _productionPlanRepository.AddAsync(newPlan);
            return Unit.Value;
        }
    }
}
