using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SodaCompany.Core.Entities
{
    public partial class WorkProcedure
    {
        public WorkProcedure()
        {
            ProductionPlanWorkProcedure = new HashSet<ProductionPlanWorkProcedure>();
            WorkProcedurePart = new HashSet<WorkProcedurePart>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal ProductionPrice { get; set; }
        public Guid? ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual ICollection<ProductionPlanWorkProcedure> ProductionPlanWorkProcedure { get; set; }
        public virtual ICollection<WorkProcedurePart> WorkProcedurePart { get; set; }
    }
}
