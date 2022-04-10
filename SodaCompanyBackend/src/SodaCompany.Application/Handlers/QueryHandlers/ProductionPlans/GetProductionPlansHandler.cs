using MediatR;
using SodaCompany.Application.Mappers;
using SodaCompany.Application.Queries.ProductionPlans;
using SodaCompany.Application.Responses.ProductionPlans;
using SodaCompany.Application.Responses.Wrappers;
using SodaCompany.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SodaCompany.Application.Handlers.QueryHandlers.ProductionPlans
{
    public class GetProductionPlansHandler : IRequestHandler<GetProductionPlansQuery, PagedResponse<IReadOnlyList<ProductionPlanResponse>>>
    {
        private readonly IProductionPlanRepository _productionPlanRepository;

        public GetProductionPlansHandler(IProductionPlanRepository productionPlanRepository)
        {
            _productionPlanRepository = productionPlanRepository;
        }
        public async Task<PagedResponse<IReadOnlyList<ProductionPlanResponse>>> Handle(GetProductionPlansQuery request, CancellationToken cancellationToken)
        {
            var totalRecord = await _productionPlanRepository.GetNumberOfRecord();

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

            var data = ProductionPlanMapper.Mapper.Map<IReadOnlyList<ProductionPlanResponse>>(await _productionPlanRepository.GetEntitiesPaged(request.RecordsPerPage, request.PageNumber));

            var response = new PagedResponse<IReadOnlyList<ProductionPlanResponse>>(data, request.PageNumber, request.RecordsPerPage, totalRecord);
            return response;
        }
    }
}
