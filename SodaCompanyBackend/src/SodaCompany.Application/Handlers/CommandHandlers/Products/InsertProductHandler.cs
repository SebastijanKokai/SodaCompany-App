using MediatR;
using SodaCompany.Application.Commands.Products;
using SodaCompany.Application.Mappers;
using SodaCompany.Core.Entities;
using SodaCompany.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.CommandHandlers.Products
{
    public class InsertProductHandler : IRequestHandler<InsertProductCommand, Unit>
    {
        private readonly IProductsRepository _productsRepository;

        public InsertProductHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public async Task<Unit> Handle(InsertProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = ProductMapper.Mapper.Map<Product>(request);
            await _productsRepository.AddAsync(newProduct);
            return Unit.Value;
        }
    }
}
