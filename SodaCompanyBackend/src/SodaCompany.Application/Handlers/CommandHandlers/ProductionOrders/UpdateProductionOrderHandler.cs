using MediatR;
using SodaCompany.Application.Commands.ProductionOrders;
using SodaCompany.Application.Mappers;
using SodaCompany.Application.Responses.ProductionOrders;
using SodaCompany.Core.Entities;
using SodaCompany.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.CommandHandlers.ProductionOrders
{
    public class UpdateProductionOrderHandler : IRequestHandler<UpdateProductionOrderCommand, ProductionOrderResponse>
    {
        private readonly IProductionOrderRepository _productionOrderRepository;

        public UpdateProductionOrderHandler(IProductionOrderRepository productionOrderRepository)
        {
            _productionOrderRepository = productionOrderRepository;
        }
        public async Task<ProductionOrderResponse> Handle(UpdateProductionOrderCommand request, CancellationToken cancellationToken)
        {
            var oldProductionOrder = await _productionOrderRepository.GetByIdAsync(request.Id);
            if (oldProductionOrder == null)
                return null;
            var updatedOrderedProducts = ProductionOrderMapper.Mapper.Map<List<ProductionOrderProduct>>(request.OrderProducts).Select(product =>
            {
                product.ProductionOrderId = oldProductionOrder.Id;
                return product;
            }).ToList();
            await _productionOrderRepository.DeleteAllOrderProducts(oldProductionOrder.Id);
            oldProductionOrder.ProductionOrderProduct = updatedOrderedProducts;
            oldProductionOrder.Name = request.Name;
            await _productionOrderRepository.UpdateAsync(oldProductionOrder);
            return ProductionOrderMapper.Mapper.Map<ProductionOrderResponse>(oldProductionOrder);
        }
    }
}
