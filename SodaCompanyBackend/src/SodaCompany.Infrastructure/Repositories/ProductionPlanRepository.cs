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
    public class ProductionPlanRepository : Repository<ProductionPlan>, IProductionPlanRepository
    {
        public ProductionPlanRepository(SodaCompanyContext sodaCompanyContext) : base(sodaCompanyContext)
        {
        }

        public async Task DeleteAllWorkProceduresOfPlan(Guid planId)
        {
            var workProceduresOfPlan = await _sodaCompanyContext.ProductionPlanWorkProcedure.Where(procedure => procedure.ProductionPlanId == planId).ToListAsync();
            _sodaCompanyContext.ProductionPlanWorkProcedure.RemoveRange(workProceduresOfPlan);
        }

        public async Task<ProductionPlan> GetProductionPlanByProductionOrderId(Guid productionOrderId)
        {
            return await Task.FromResult(_sodaCompanyContext.ProductionPlan.FirstOrDefault(plan => plan.ProductionOrderId == productionOrderId));
        }
    }
}
