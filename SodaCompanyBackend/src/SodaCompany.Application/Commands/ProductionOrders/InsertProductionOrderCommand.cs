﻿using MediatR;
using SodaCompany.Application.Dtos;
using SodaCompany.Application.Responses.ProductionOrders;
using System;
using System.Collections.Generic;

namespace SodaCompany.Application.Commands.ProductionOrders
{
    public class InsertProductionOrderCommand : IRequest<ProductionOrderResponse>
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public List<OrderProductDto> OrderProducts { get; set; }
    }
}
