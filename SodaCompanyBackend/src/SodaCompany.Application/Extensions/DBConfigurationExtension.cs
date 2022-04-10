using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SodaCompany.Infrastructure.Data;
using System;

namespace SodaCompany.Application.Extensions
{
    public static class DBConfigurationExtension
    {
        public static IServiceCollection AddSodaCompanyDBService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SodaCompanyContext>(m =>
            {
                if (Convert.ToBoolean(configuration["IsMockedDB"]))
                    m.UseInMemoryDatabase(databaseName: "soda_company");
                else
                    m.UseSqlServer(configuration.GetConnectionString("SodaCompanyDB"));
            }, ServiceLifetime.Singleton);

            return services;
        }
    }
}
