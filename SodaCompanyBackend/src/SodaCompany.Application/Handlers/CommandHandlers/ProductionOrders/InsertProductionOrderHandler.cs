using MediatR;
using SodaCompany.Application.Commands.ProductionOrders;
using SodaCompany.Application.Mappers;
using SodaCompany.Core.Entities;
using SodaCompany.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.CommandHandlers.ProductionOrders
{
    public class InsertProductionOrderHandler : IRequestHandler<InsertProductionOrderCommand, Unit>
    {
        private readonly IProductionOrderRepository _productionOrderRepository;

        public InsertProductionOrderHandler(IProductionOrderRepository productionOrderRepository)
        {
            _productionOrderRepository = productionOrderRepository;
        }

        public async Task<Unit> Handle(InsertProductionOrderCommand request, CancellationToken cancellationToken)
        {
            var newOrder = ProductionOrderMapper.Mapper.Map<ProductionOrder>(request);
            var orderedProducts = ProductionOrderMapper.Mapper.Map<List<ProductionOrderProduct>>(request.OrderProducts).Select(product =>
            {
                product.ProductionOrderId = newOrder.Id;
                return product;
            }).ToList();
            newOrder.ProductionOrderProduct = orderedProducts;
            var createdOrder = await _productionOrderRepository.AddAsync(newOrder);
            return Unit.Value;
        }
    }
}
