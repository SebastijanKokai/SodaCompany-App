using SodaCompany.Core.Entities;
using SodaCompany.Core.Repositories.Base;

namespace SodaCompany.Core.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        public Employee GetEmployeeByUsername(string username);
    }
}
