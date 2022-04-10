using SodaCompany.Core.Entities;
using SodaCompany.Core.Repositories;
using SodaCompany.Infrastructure.Data;
using SodaCompany.Infrastructure.Repositories.Base;
using System.Linq;

namespace SodaCompany.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(SodaCompanyContext sodaCompanyContext) : base(sodaCompanyContext)
        {
        }
        public Employee GetEmployeeByUsername(string username)
        {
            return _sodaCompanyContext.Employee.FirstOrDefault(employee => string.Equals(username, employee.Username));
        }
    }
}
