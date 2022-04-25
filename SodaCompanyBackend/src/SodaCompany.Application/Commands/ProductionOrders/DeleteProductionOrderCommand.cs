using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SodaCompany.Application.Commands.ProductionOrders
{
    public class DeleteProductionOrderCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
