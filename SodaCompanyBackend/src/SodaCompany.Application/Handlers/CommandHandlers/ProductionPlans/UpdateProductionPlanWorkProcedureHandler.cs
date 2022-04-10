using MediatR;
using SodaCompany.Application.Commands.ProductionPlans;
using SodaCompany.Core.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.CommandHandlers.ProductionPlans
{
    public class UpdateProductionPlanWorkProcedureHandler : IRequestHandler<UpdateProductionPlanWorkProcedureCommand, Unit>
    {
        private readonly IProductionPlanRepository _productionPlanRepository;

        public UpdateProductionPlanWorkProcedureHandler(IProductionPlanRepository productionPlanRepository)
        {
            _productionPlanRepository = productionPlanRepository;
        }
        public async Task<Unit> Handle(UpdateProductionPlanWorkProcedureCommand request, CancellationToken cancellationToken)
        {
            var oldPlan = await _productionPlanRepository.GetByIdAsync(request.ProductionPlanId);
            var oldWorkProcedure = oldPlan.ProductionPlanWorkProcedure.FirstOrDefault(workProcedure => workProcedure.WorkProcedureId == request.OldWorkProcedureId);
            oldWorkProcedure.WorkProcedureId = request.NewWorkProcedureId;
            oldWorkProcedure.Quantity = request.Quantity;
            await _productionPlanRepository.UpdateAsync(oldPlan);
            return Unit.Value;
        }
    }
}
