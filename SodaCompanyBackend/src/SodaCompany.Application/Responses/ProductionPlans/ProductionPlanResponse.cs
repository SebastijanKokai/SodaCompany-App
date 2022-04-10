using System;
using System.Collections.Generic;

namespace SodaCompany.Application.Responses.ProductionPlans
{
    public class ProductionPlanResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ProductionDeadline { get; set; }

        public Guid CreatedByNavigationId { get; set; }
        public string CreatedByNavigationName { get; set; }
        public string CreatedByNavigationSurname { get; set; }
        public string CreatedByNavigationPhoneNumber { get; set; }
        public string CreatedByNavigationOrganizationalUnitName { get; set; }
        public string CreatedByNavigationEmployeeTypeType { get; set; }


        public Guid ProductionOrderId { get; set; }
        public string ProductionOrderName { get; set; }
        public DateTime ProductionOrderCreationDate { get; set; }

        public ICollection<ProductionPlanItem> ProductionPlanWorkProcedure { get; set; }
        public decimal TotalProductionCost { get; set; }
    }
    public class ProductionPlanItem
    {
        /*public WorkProcedureResponse WorkProcedure { get; set; }
        public decimal Quantity { get; set; }*/
        public Guid Id { get; set; }
        public decimal Quantity { get; set; }

        public Guid WorkProcedureId { get; set; }
        public string WorkProcedureName { get; set; }
        public string WorkProcedureDescription { get; set; }
        public decimal WorkProcedureProductionPrice { get; set; }

        public Guid WorkProcedureProductId { get; set; }
        public string WorkProcedureProductName { get; set; }

        public string WorkProcedureProductProductModelUnit { get; set; }
        public decimal WorkProcedureProductProductModelValue { get; set; }
        public string WorkProcedureProductProductModelType { get; set; }
        public decimal WorkProcedureProductProductModelWidth { get; set; }
        public decimal WorkProcedureProductProductModelHeight { get; set; }

        public ICollection<ProductPart> WorkProcedureWorkProcedurePart { get; set; }
    }
    public class ProductPart
    {
        public Guid Id { get; set; }
        public decimal Quantity { get; set; }
        public Guid PartId { get; set; }
        public string PartName { get; set; }
        public decimal PartPrice { get; set; }
    }
}
