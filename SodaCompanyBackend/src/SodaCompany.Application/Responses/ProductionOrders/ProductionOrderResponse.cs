using System;
using System.Collections.Generic;

namespace SodaCompany.Application.Responses.ProductionOrders
{
    public class ProductionOrderResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public string CreatedByNavigationName { get; set; }
        public string CreatedByNavigationSurname { get; set; }

        public ICollection<OrderItem> OrderedProducts { get; set; }

    }
    public class OrderItem
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }

        public string ProductProductModelId { get; set; }
        public string ProductProductModelUnit { get; set; }
        public decimal ProductProductModelValue { get; set; }
        public string ProductProductModelType { get; set; }
        public decimal ProductProductModelWidth { get; set; }
        public decimal ProductProductModelHeight { get; set; }
        public decimal Quantity { get; set; }
    }
}
