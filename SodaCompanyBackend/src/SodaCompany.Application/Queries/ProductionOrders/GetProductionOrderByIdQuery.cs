using MediatR;
using SodaCompany.Application.Responses.ProductionOrders;
using System;

namespace SodaCompany.Application.Queries.ProductionOrders
{
    public class GetProductionOrderByIdQuery : IRequest<ProductionOrderResponse>
    {
        public Guid Id { get; set; }
    }
}
