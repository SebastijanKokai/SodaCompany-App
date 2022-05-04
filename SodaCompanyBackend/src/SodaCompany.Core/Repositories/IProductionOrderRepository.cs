using SodaCompany.Core.Entities;
using SodaCompany.Core.Repositories.Base;
using System;
using System.Threading.Tasks;

namespace SodaCompany.Core.Repositories
{
    public interface IProductionOrderRepository : IRepository<ProductionOrder>
    {
        public Task DeleteAllOrderProducts(Guid productionOrderId);
        public Task DeleteAllOrderProductionPlans(Guid productionOrderId);
    }
}
