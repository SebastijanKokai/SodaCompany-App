using SodaCompany.Core.Entities;
using SodaCompany.Core.Repositories;
using SodaCompany.Infrastructure.Data;
using SodaCompany.Infrastructure.Repositories.Base;

namespace SodaCompany.Infrastructure.Repositories
{
    public class EmployeeTypeRepository : Repository<EmployeeType>, IEmployeeTypeRepository
    {
        public EmployeeTypeRepository(SodaCompanyContext sodaCompanyContext) : base(sodaCompanyContext)
        {
        }
    }
}
