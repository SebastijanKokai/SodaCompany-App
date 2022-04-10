using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SodaCompany.Core.Entities
{
    public partial class EmployeeType
    {
        public EmployeeType()
        {
            Employee = new HashSet<Employee>();
        }

        public Guid Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
