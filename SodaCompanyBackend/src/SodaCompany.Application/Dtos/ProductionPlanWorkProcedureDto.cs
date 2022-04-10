using System;

namespace SodaCompany.Application.Dtos
{
    public class ProductionPlanWorkProcedureDto
    {
        public decimal Quantity { get; set; }
        public Guid? WorkProcedureId { get; set; }
    }
}
