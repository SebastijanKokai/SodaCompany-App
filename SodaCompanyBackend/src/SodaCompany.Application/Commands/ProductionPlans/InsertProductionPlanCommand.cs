﻿using MediatR;
using SodaCompany.Application.Dtos;
using SodaCompany.Application.Responses.ProductionPlans;
using System;
using System.Collections.Generic;

namespace SodaCompany.Application.Commands.ProductionPlans
{
    public class InsertProductionPlanCommand : IRequest<ProductionPlanResponse>
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ProductionDeadline { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ProductionOrderId { get; set; }
        public List<ProductionPlanWorkProcedureDto> PlanWorkProcedures { get; set; }
    }
}
