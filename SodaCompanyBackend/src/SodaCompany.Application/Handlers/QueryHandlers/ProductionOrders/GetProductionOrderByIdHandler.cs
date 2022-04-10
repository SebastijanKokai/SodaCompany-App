using MediatR;
using SodaCompany.Application.Mappers;
using SodaCompany.Application.Queries.Products;
using SodaCompany.Application.Responses.Products;
using SodaCompany.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.QueryHandlers.ProductionOrder
{
    public class GetProductionOrderByIdHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
    {
        private readonly IProductionOrderRepository _productionOrderRepository;

        public GetProductionOrderByIdHandler(IProductionOrderRepository productionOrderRepository)
        {
            _productionOrderRepository = productionOrderRepository;
        }

        public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return ProductMapper.Mapper.Map<ProductResponse>(await _productionOrderRepository.GetByIdAsync(request.Id));
        }
    }
}
