using System;
using System.Collections.Generic;

namespace SodaCompany.Application.Responses.Products
{
    public class ProductResponse
    {

        public Guid Id { get; set; }
        public string Name { get; set; }

        public string ProductModelId { get; set; }
        public string ProductModelUnit { get; set; }
        public decimal ProductModelValue { get; set; }
        public string ProductModelType { get; set; }
        public decimal ProductModelWidth { get; set; }
        public decimal ProductModelHeight { get; set; }
        public ICollection<WorkProcedureItem> WorkProcedure { get; set; }
    }
    public class WorkProcedureItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal ProductionPrice { get; set; }
        public virtual ICollection<PartProduct> WorkProcedurePart { get; set; }
    }
    public class PartProduct
    {
        public Guid Id { get; set; }
        public decimal Quantity { get; set; }

        public Guid PartId { get; set; }
        public string PartName { get; set; }
        public decimal PartPrice { get; set; }
    }
}
