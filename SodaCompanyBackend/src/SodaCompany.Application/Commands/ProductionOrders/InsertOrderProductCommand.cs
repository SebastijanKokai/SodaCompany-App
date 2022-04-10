using MediatR;
using System;

namespace SodaCompany.Application.Commands.ProductionOrders
{
    public class InsertOrderProductCommand : IRequest<Unit>
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public decimal Quantity { get; set; }
    }
}
