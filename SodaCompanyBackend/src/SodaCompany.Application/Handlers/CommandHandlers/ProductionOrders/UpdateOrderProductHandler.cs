using MediatR;
using SodaCompany.Application.Commands.ProductionOrders;
using SodaCompany.Core.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.CommandHandlers.ProductionOrders
{
    public class UpdateOrderProductHandler : IRequestHandler<UpdateOrderProductCommand, Unit>
    {
        private readonly IProductionOrderRepository _productionOrderRepository;

        public UpdateOrderProductHandler(IProductionOrderRepository productionOrderRepository)
        {
            _productionOrderRepository = productionOrderRepository;
        }
        public async Task<Unit> Handle(UpdateOrderProductCommand request, CancellationToken cancellationToken)
        {
            var oldOrder = await _productionOrderRepository.GetByIdAsync(request.OrderId);
            var oldProduct = oldOrder.ProductionOrderProduct.FirstOrDefault(product => product.ProductId == request.OldProductId);
            oldProduct.ProductId = request.NewProductId;
            oldProduct.Quantity = request.Quantity;
            await _productionOrderRepository.UpdateAsync(oldOrder);
            return Unit.Value;
        }
    }
}
