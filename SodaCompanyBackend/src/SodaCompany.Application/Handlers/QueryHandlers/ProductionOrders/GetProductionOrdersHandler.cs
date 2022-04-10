using MediatR;
using SodaCompany.Application.Mappers;
using SodaCompany.Application.Queries.ProductionOrders;
using SodaCompany.Application.Responses.ProductionOrders;
using SodaCompany.Application.Responses.Wrappers;
using SodaCompany.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.QueryHandlers.Products
{
    public class GetProductionOrdersHandler : IRequestHandler<GetProductionOrderQuery, PagedResponse<IReadOnlyList<ProductionOrderResponse>>>
    {
        private readonly IProductionOrderRepository _productionOrderRepository;

        public GetProductionOrdersHandler(IProductionOrderRepository productionOrderRepository)
        {
            _productionOrderRepository = productionOrderRepository;
        }
        public async Task<PagedResponse<IReadOnlyList<ProductionOrderResponse>>> Handle(GetProductionOrderQuery request, CancellationToken cancellationToken)
        {
            var totalRecord = await _productionOrderRepository.GetNumberOfRecord();

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

            var data = ProductionOrderMapper.Mapper.Map<IReadOnlyList<ProductionOrderResponse>>(await _productionOrderRepository.GetEntitiesPaged(request.RecordsPerPage, request.PageNumber));

            var response = new PagedResponse<IReadOnlyList<ProductionOrderResponse>>(data, request.PageNumber, request.RecordsPerPage, totalRecord);
            return response;
        }
    }
}
