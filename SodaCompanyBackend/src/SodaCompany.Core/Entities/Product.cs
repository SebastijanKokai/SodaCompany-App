using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SodaCompany.Core.Entities
{
    public partial class Product
    {
        public Product()
        {
            ProductionOrderProduct = new HashSet<ProductionOrderProduct>();
            WorkProcedure = new HashSet<WorkProcedure>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ProductModelId { get; set; }

        public virtual ProductModel ProductModel { get; set; }
        public virtual ICollection<ProductionOrderProduct> ProductionOrderProduct { get; set; }
        public virtual ICollection<WorkProcedure> WorkProcedure { get; set; }
    }
}
