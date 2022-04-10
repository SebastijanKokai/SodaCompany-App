using MediatR;
using SodaCompany.Application.Commands.ProductionOrders;
using SodaCompany.Application.Mappers;
using SodaCompany.Core.Entities;
using SodaCompany.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.CommandHandlers.ProductionOrders
{
    public class InsertOrderProductHandler : IRequestHandler<InsertOrderProductCommand, Unit>
    {
        private readonly IProductionOrderRepository _productionOrderRepository;

        public InsertOrderProductHandler(IProductionOrderRepository productionOrderRepository)
        {
            _productionOrderRepository = productionOrderRepository;
        }
        public async Task<Unit> Handle(InsertOrderProductCommand request, CancellationToken cancellationToken)
        {
            var oldOrder = await _productionOrderRepository.GetByIdAsync(request.OrderId);
            oldOrder.ProductionOrderProduct.Add(ProductionOrderMapper.Mapper.Map<ProductionOrderProduct>(request));
            await _productionOrderRepository.UpdateAsync(oldOrder);
            return Unit.Value;
        }
    }
}
