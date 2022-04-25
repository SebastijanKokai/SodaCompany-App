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

        public Task DeleteAllOrderProducts(Guid productionOrderId)
        {
            var productionOrderItems = _sodaCompanyContext.ProductionOrderProduct.Where(orderProduct=>orderProduct.ProductionOrderId==productionOrderId).ToList();
            _sodaCompanyContext.ProductionOrderProduct.RemoveRange(productionOrderItems);
            return Task.CompletedTask;
        }
    }
}
