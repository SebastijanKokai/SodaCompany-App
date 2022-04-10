using Microsoft.Extensions.DependencyInjection;
using SodaCompany.Core.Repositories;
using SodaCompany.Core.Repositories.Base;
using SodaCompany.Infrastructure.Repositories;
using SodaCompany.Infrastructure.Repositories.Base;

namespace SodaCompany.Application.Extensions
{
    public static class RepositoriesConfigurationExtension
    {
        public static IServiceCollection AddSodaCompanyRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddTransient<IEmployeeTypeRepository, EmployeeTypeRepository>();
            services.AddTransient<IProductionOrderRepository, ProductionOrderRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IProductionPlanRepository, ProductionPlanRepository>();
            return services;
        }
    }
}
