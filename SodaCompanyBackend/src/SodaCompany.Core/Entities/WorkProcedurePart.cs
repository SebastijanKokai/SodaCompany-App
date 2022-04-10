using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SodaCompany.Core.Entities
{
    public partial class WorkProcedurePart
    {
        public Guid Id { get; set; }
        public Guid? PartId { get; set; }
        public Guid? WorkProcedureId { get; set; }
        public decimal Quantity { get; set; }

        public virtual Part Part { get; set; }
        public virtual WorkProcedure WorkProcedure { get; set; }
    }
}
