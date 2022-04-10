using MediatR;
using SodaCompany.Application.Commands.ProductionPlans;
using SodaCompany.Application.Mappers;
using SodaCompany.Core.Entities;
using SodaCompany.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.CommandHandlers.ProductionPlans
{
    public class InsertProductionPlanWorkProcedureHandler : IRequestHandler<InsertProductionPlanWorkProcedureCommand, Unit>
    {
        private readonly IProductionPlanRepository _productionPlanRepository;

        public InsertProductionPlanWorkProcedureHandler(IProductionPlanRepository productionPlanRepository)
        {
            _productionPlanRepository = productionPlanRepository;
        }
        public async Task<Unit> Handle(InsertProductionPlanWorkProcedureCommand request, CancellationToken cancellationToken)
        {
            var oldOrder = await _productionPlanRepository.GetByIdAsync(request.ProductionPlanId);
            oldOrder.ProductionPlanWorkProcedure.Add(ProductionPlanMapper.Mapper.Map<ProductionPlanWorkProcedure>(request));
            await _productionPlanRepository.UpdateAsync(oldOrder);
            return Unit.Value;
        }
    }
}
