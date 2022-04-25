using MediatR;
using SodaCompany.Application.Dtos;
using SodaCompany.Application.Responses.ProductionOrders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SodaCompany.Application.Commands.ProductionOrders
{
    public class UpdateProductionOrderCommand : IRequest<ProductionOrderResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<OrderProductDto> OrderProducts { get; set; }
    }
}
