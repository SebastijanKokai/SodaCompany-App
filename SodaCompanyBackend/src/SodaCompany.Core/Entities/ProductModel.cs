using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SodaCompany.Core.Entities
{
    public partial class ProductModel
    {
        public ProductModel()
        {
            Product = new HashSet<Product>();
        }

        public Guid Id { get; set; }
        public string Unit { get; set; }
        public decimal Value { get; set; }
        public string Type { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
