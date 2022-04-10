using MediatR;
using SodaCompany.Application.Mappers;
using SodaCompany.Application.Queries.Products;
using SodaCompany.Application.Responses.Products;
using SodaCompany.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.QueryHandlers.Products
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
    {
        private readonly IProductsRepository _productsRepository;

        public GetProductByIdHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return ProductMapper.Mapper.Map<ProductResponse>(await _productsRepository.GetByIdAsync(request.Id));
        }
    }
}
