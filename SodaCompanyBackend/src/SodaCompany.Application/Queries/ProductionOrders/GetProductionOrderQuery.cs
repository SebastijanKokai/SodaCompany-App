using MediatR;
using SodaCompany.Application.Queries.Base;
using SodaCompany.Application.Responses.ProductionOrders;
using SodaCompany.Application.Responses.Wrappers;
using System.Collections.Generic;

namespace SodaCompany.Application.Queries.ProductionOrders
{
    public class GetProductionOrderQuery : BasePagedQuery, IRequest<PagedResponse<IReadOnlyList<ProductionOrderResponse>>>
    {
    }
}
