using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SodaCompany.Core.Entities
{
    public partial class ProductionOrder
    {
        public ProductionOrder()
        {
            ProductionOrderProduct = new HashSet<ProductionOrderProduct>();
            ProductionPlan = new HashSet<ProductionPlan>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid? CreatedBy { get; set; }

        public virtual Employee CreatedByNavigation { get; set; }
        public virtual ICollection<ProductionOrderProduct> ProductionOrderProduct { get; set; }
        public virtual ICollection<ProductionPlan> ProductionPlan { get; set; }
    }
}
