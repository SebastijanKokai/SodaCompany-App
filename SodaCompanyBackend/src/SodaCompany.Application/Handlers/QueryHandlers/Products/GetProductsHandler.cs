using MediatR;
using SodaCompany.Application.Mappers;
using SodaCompany.Application.Queries.Products;
using SodaCompany.Application.Responses.Products;
using SodaCompany.Application.Responses.Wrappers;
using SodaCompany.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.QueryHandlers.Products
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, PagedResponse<IReadOnlyList<ProductResponse>>>
    {
        private readonly IProductsRepository _productsRepository;

        public GetProductsHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public async Task<PagedResponse<IReadOnlyList<ProductResponse>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var totalRecord = await _productsRepository.GetNumberOfRecord();

            if (request.RecordsPerPage < 1)
                request.RecordsPerPage = 10;

            if (request.PageNumber < 1)
            {

                request.PageNumber = 1;
                request.RecordsPerPage = totalRecord;
            }

            var numberOfPages = Convert.ToInt32(Math.Ceiling((double)totalRecord / (double)request.RecordsPerPage));

            if (numberOfPages < request.PageNumber)
                request.PageNumber = numberOfPages;

            var data = ProductMapper.Mapper.Map<IReadOnlyList<ProductResponse>>(await _productsRepository.GetEntitiesPaged(request.RecordsPerPage, request.PageNumber));

            var response = new PagedResponse<IReadOnlyList<ProductResponse>>(data, request.PageNumber, request.RecordsPerPage, totalRecord);
            return response;
        }
    }
}
