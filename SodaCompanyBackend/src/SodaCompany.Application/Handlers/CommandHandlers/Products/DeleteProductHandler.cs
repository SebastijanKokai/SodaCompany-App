using MediatR;
using SodaCompany.Application.Commands.Products;
using SodaCompany.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.CommandHandlers.Products
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductsRepository _productsRepository;

        public DeleteProductHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productsRepository.GetByIdAsync(request.Id);
            if (product is null)
                return Unit.Value;
            await _productsRepository.DeleteAsync(product);
            return Unit.Value;
        }
    }
}
