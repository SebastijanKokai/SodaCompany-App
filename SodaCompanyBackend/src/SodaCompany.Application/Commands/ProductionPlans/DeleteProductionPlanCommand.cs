using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SodaCompany.Application.Commands.ProductionPlans
{
    public class DeleteProductionPlanCommand : IRequest<Unit>
    {
        public Guid Id { get;set; }
    }
}
