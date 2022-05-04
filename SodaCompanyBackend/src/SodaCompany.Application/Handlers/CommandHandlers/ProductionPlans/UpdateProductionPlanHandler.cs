using MediatR;
using SodaCompany.Application.Commands.ProductionPlans;
using SodaCompany.Application.Mappers;
using SodaCompany.Application.Responses.ProductionPlans;
using SodaCompany.Core.Entities;
using SodaCompany.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.CommandHandlers.ProductionPlans
{
    public class UpdateProductionPlanHandler : IRequestHandler<UpdateProductionPlanCommand, ProductionPlanResponse>
    {
        private readonly IProductionPlanRepository _productionPlanRepository;

        public UpdateProductionPlanHandler(IProductionPlanRepository productionPlanRepository)
        {
            _productionPlanRepository = productionPlanRepository;
        }
        public async Task<ProductionPlanResponse> Handle(UpdateProductionPlanCommand request, CancellationToken cancellationToken)
        {
            var oldProductionPlan = await _productionPlanRepository.GetByIdAsync(request.Id);
            if (oldProductionPlan == null)
                return null;
            var updatedOrderedProducts = ProductionPlanMapper.Mapper.Map<List<ProductionPlanWorkProcedure>>(request.PlanWorkProcedures).Select(procedure =>
            {
                procedure.ProductionPlanId = oldProductionPlan.Id;
                return procedure;
            }).ToList();
            await _productionPlanRepository.DeleteAllWorkProceduresOfPlan(oldProductionPlan.Id);
            oldProductionPlan.ProductionPlanWorkProcedure = updatedOrderedProducts;
            oldProductionPlan.Name = request.Name;
            oldProductionPlan.ProductionDeadline = request.ProductionDeadline;
            oldProductionPlan.ProductionOrderId = request.ProductionOrderId;
            await _productionPlanRepository.UpdateAsync(oldProductionPlan);
            return ProductionPlanMapper.Mapper.Map<ProductionPlanResponse>(oldProductionPlan);
        }
    }
}
