using MediatR;
using SodaCompany.Application.Commands.Products;
using SodaCompany.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.CommandHandlers.Products
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductsRepository _productsRepository;

        public UpdateProductHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var oldProduct = await _productsRepository.GetByIdAsync(request.Id);
            if (oldProduct is null)
                return Unit.Value;
            oldProduct.Name = request.Name;
            oldProduct.ProductModelId = request.ProductModelId;
            await _productsRepository.UpdateAsync(oldProduct);
            return Unit.Value;
        }
    }
}
