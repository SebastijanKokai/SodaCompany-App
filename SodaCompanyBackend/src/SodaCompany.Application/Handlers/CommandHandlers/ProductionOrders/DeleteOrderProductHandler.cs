using MediatR;
using SodaCompany.Application.Commands.ProductionOrders;
using SodaCompany.Core.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.CommandHandlers.ProductionOrders
{
    public class DeleteOrderProductHandler : IRequestHandler<DeleteOrderProductCommand, Unit>
    {
        private readonly IProductionOrderRepository _productionOrderRepository;

        public DeleteOrderProductHandler(IProductionOrderRepository productionOrderRepository)
        {
            _productionOrderRepository = productionOrderRepository;
        }
        public async Task<Unit> Handle(DeleteOrderProductCommand request, CancellationToken cancellationToken)
        {
            var oldOrder = await _productionOrderRepository.GetByIdAsync(request.OrderId);
            oldOrder.ProductionOrderProduct = oldOrder.ProductionOrderProduct.Where(product => product.ProductId != request.ProductId).ToList();
            await _productionOrderRepository.UpdateAsync(oldOrder);
            return Unit.Value;
        }
    }
}
