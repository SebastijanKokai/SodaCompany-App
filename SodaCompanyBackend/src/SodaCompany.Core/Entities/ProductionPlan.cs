using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SodaCompany.Core.Entities
{
    public partial class ProductionPlan
    {
        public ProductionPlan()
        {
            ProductionPlanWorkProcedure = new HashSet<ProductionPlanWorkProcedure>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ProductionDeadline { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ProductionOrderId { get; set; }

        public virtual Employee CreatedByNavigation { get; set; }
        public virtual ProductionOrder ProductionOrder { get; set; }
        public virtual ICollection<ProductionPlanWorkProcedure> ProductionPlanWorkProcedure { get; set; }
    }
}
