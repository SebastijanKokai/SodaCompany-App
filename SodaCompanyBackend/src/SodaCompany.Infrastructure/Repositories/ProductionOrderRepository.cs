using SodaCompany.Core.Entities;
using SodaCompany.Core.Repositories;
using SodaCompany.Infrastructure.Data;
using SodaCompany.Infrastructure.Repositories.Base;

namespace SodaCompany.Infrastructure.Repositories
{
    public class ProductionOrderRepository : Repository<ProductionOrder>, IProductionOrderRepository
    {
        public ProductionOrderRepository(SodaCompanyContext sodaCompanyContext) : base(sodaCompanyContext)
        {
        }
    }
}
