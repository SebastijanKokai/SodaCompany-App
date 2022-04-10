using MediatR;
using SodaCompany.Application.Mappers;
using SodaCompany.Application.Queries.ProductionPlans;
using SodaCompany.Application.Responses.ProductionPlans;
using SodaCompany.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.QueryHandlers.ProductionPlans
{
    public class GetProductionPlanByProductionOrderIdHandler : IRequestHandler<GetProductionPlanByProductionOrderIdQuery, ProductionPlanResponse>
    {
        private readonly IProductionPlanRepository _productionPlanRepository;

        public GetProductionPlanByProductionOrderIdHandler(IProductionPlanRepository productionPlanRepository)
        {
            _productionPlanRepository = productionPlanRepository;
        }
        public async Task<ProductionPlanResponse> Handle(GetProductionPlanByProductionOrderIdQuery request, CancellationToken cancellationToken)
        {
            return ProductionPlanMapper.Mapper.Map<ProductionPlanResponse>(await _productionPlanRepository.GetProductionPlanByProductionOrderId(request.ProductionOrderId));
        }
    }
}
