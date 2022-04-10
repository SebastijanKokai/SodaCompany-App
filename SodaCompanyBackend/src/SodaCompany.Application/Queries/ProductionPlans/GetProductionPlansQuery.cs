using MediatR;
using SodaCompany.Application.Queries.Base;
using SodaCompany.Application.Responses.ProductionPlans;
using SodaCompany.Application.Responses.Wrappers;
using System.Collections.Generic;

namespace SodaCompany.Application.Queries.ProductionPlans
{
    public class GetProductionPlansQuery : BasePagedQuery, IRequest<PagedResponse<IReadOnlyList<ProductionPlanResponse>>>
    {
    }
}
