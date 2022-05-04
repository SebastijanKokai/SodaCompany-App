using Microsoft.EntityFrameworkCore;
using SodaCompany.Core.Entities;
using SodaCompany.Core.Repositories;
using SodaCompany.Infrastructure.Data;
using SodaCompany.Infrastructure.Repositories.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SodaCompany.Infrastructure.Repositories
{
    public class ProductionOrderRepository : Repository<ProductionOrder>, IProductionOrderRepository
    {
        public ProductionOrderRepository(SodaCompanyContext sodaCompanyContext) : base(sodaCompanyContext)
        {
        }

        public async Task DeleteAllOrderProductionPlans(Guid productionOrderId)
        {
            var productionPlans = await _sodaCompanyContext.ProductionPlan.Where(plan => plan.ProductionOrderId == productionOrderId).ToListAsync();
            _sodaCompanyContext.ProductionPlan.RemoveRange(productionPlans);
        }

        public async Task DeleteAllOrderProducts(Guid productionOrderId)
        {
            var productionOrderItems = await _sodaCompanyContext.ProductionOrderProduct.Where(orderProduct=>orderProduct.ProductionOrderId==productionOrderId).ToListAsync();
            _sodaCompanyContext.ProductionOrderProduct.RemoveRange(productionOrderItems);
        }
    }
}
