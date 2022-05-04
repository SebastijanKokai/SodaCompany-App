using SodaCompany.Core.Entities;
using SodaCompany.Core.Repositories.Base;
using System;
using System.Threading.Tasks;

namespace SodaCompany.Core.Repositories
{
    public interface IProductionPlanRepository : IRepository<ProductionPlan>
    {
        Task<ProductionPlan> GetProductionPlanByProductionOrderId(Guid productionOrderId);
        Task DeleteAllWorkProceduresOfPlan(Guid planId);
    }
}
