using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SodaCompany.Core.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            ProductionOrder = new HashSet<ProductionOrder>();
            ProductionPlan = new HashSet<ProductionPlan>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public Guid? EmployeeTypeId { get; set; }
        public Guid? OrganizationalUnitId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public virtual EmployeeType EmployeeType { get; set; }
        public virtual OrganizationalUnit OrganizationalUnit { get; set; }
        public virtual ICollection<ProductionOrder> ProductionOrder { get; set; }
        public virtual ICollection<ProductionPlan> ProductionPlan { get; set; }
    }
}
