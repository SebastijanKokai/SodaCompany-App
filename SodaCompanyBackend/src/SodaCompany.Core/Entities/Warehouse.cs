using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SodaCompany.Core.Entities
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            WarehousePart = new HashSet<WarehousePart>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<WarehousePart> WarehousePart { get; set; }
    }
}
