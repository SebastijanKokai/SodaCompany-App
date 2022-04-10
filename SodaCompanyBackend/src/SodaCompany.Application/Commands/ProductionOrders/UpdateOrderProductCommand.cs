using MediatR;
using System;

namespace SodaCompany.Application.Commands.ProductionOrders
{
    public class UpdateOrderProductCommand : IRequest<Unit>
    {
        public Guid OldProductId { get; set; }
        public Guid NewProductId { get; set; }
        public Guid OrderId { get; set; }
        public decimal Quantity { get; set; }
    }
}
