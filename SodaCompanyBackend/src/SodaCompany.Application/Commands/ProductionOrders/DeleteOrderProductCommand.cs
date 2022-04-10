using MediatR;
using System;

namespace SodaCompany.Application.Commands.ProductionOrders
{
    public class DeleteOrderProductCommand : IRequest<Unit>
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
    }
}
