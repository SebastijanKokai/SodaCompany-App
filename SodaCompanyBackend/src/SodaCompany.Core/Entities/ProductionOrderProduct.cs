using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SodaCompany.Core.Entities
{
    public partial class ProductionOrderProduct
    {
        public Guid Id { get; set; }
        public decimal Quantity { get; set; }
        public Guid? ProductionOrderId { get; set; }
        public Guid? ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductionOrder ProductionOrder { get; set; }
    }
}
