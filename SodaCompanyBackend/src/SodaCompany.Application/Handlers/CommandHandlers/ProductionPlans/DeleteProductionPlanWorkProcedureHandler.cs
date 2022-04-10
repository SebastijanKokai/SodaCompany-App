using MediatR;
using SodaCompany.Application.Commands.ProductionPlans;
using SodaCompany.Core.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.CommandHandlers.ProductionPlans
{
    public class DeleteProductionPlanWorkProcedureHandler : IRequestHandler<DeleteProductionPlanWorkProcedureCommand, Unit>
    {
        private readonly IProductionPlanRepository _productionPlanRepository;

        public DeleteProductionPlanWorkProcedureHandler(IProductionPlanRepository productionPlanRepository)
        {
            _productionPlanRepository = productionPlanRepository;
        }
        public async Task<Unit> Handle(DeleteProductionPlanWorkProcedureCommand request, CancellationToken cancellationToken)
        {
            var oldPlan = await _productionPlanRepository.GetByIdAsync(request.ProductionPlanId);
            oldPlan.ProductionPlanWorkProcedure = oldPlan.ProductionPlanWorkProcedure.Where(wp => wp.WorkProcedureId != request.WorkProcedureId).ToList();
            await _productionPlanRepository.UpdateAsync(oldPlan);
            return Unit.Value;
        }
    }
}
