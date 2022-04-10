using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SodaCompany.Core.Entities
{
    public partial class ProductionPlanWorkProcedure
    {
        public Guid Id { get; set; }
        public Guid? ProductionPlanId { get; set; }
        public Guid? WorkProcedureId { get; set; }
        public decimal Quantity { get; set; }

        public virtual ProductionPlan ProductionPlan { get; set; }
        public virtual WorkProcedure WorkProcedure { get; set; }
    }
}
