using MediatR;
using SodaCompany.Application.Commands.ProductionOrders;
using SodaCompany.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.CommandHandlers.ProductionOrders
{
    public class DeleteProductionOrderHandler : IRequestHandler<DeleteProductionOrderCommand, Unit>
    {
        private readonly IProductionOrderRepository _productionOrderRepository;

        public DeleteProductionOrderHandler(IProductionOrderRepository productionOrderRepository)
        {
            _productionOrderRepository = productionOrderRepository;
        }
        public async Task<Unit> Handle(DeleteProductionOrderCommand request, CancellationToken cancellationToken)
        {
            var productOrder = await _productionOrderRepository.GetByIdAsync(request.Id);
            if (productOrder != null)
                await _productionOrderRepository.DeleteAsync(productOrder);
            return Unit.Value;
        }
    }
}
