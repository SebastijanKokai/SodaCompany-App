using MediatR;
using SodaCompany.Application.Commands.ProductionPlans;
using SodaCompany.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.CommandHandlers.ProductionPlans
{
    public class DeleteProductionPlanHandler : IRequestHandler<DeleteProductionPlanCommand, Unit>
    {
        private readonly IProductionPlanRepository _productionPlanRepository;

        public DeleteProductionPlanHandler(IProductionPlanRepository productionPlanRepository)
        {
            _productionPlanRepository = productionPlanRepository;
        }
        public async Task<Unit> Handle(DeleteProductionPlanCommand request, CancellationToken cancellationToken)
        {
            var productionPlan = await _productionPlanRepository.GetByIdAsync(request.Id);
            if (productionPlan is null)
                return Unit.Value;
            await _productionPlanRepository.DeleteAllWorkProceduresOfPlan(request.Id);
            await _productionPlanRepository.DeleteAsync(productionPlan);
            return Unit.Value;
        }
    }
}
