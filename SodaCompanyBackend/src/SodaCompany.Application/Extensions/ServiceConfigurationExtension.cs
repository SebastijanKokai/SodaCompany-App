using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SodaCompany.Application.Mappers;
using SodaCompany.Application.Queries.Products;
using SodaCompany.Application.Services;
using SodaCompany.Application.Services.Interfaces;
using SodaCompany.Common.Options;
using System.Reflection;
using System.Text;

namespace SodaCompany.Application.Extensions
{
    public static class ServiceConfigurationExtension
    {
        public static IServiceCollection AddSodaCompanyServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAutoMapper(typeof(ProductMapperProfile));
            services.AddAutoMapper(typeof(EmployeeTypeMapperProfile));
            services.AddAutoMapper(typeof(ProductionOrderMapperProfile));
            services.AddAutoMapper(typeof(ProductionPlanMapperProfile));
            services.AddMediatR(typeof(GetProductsQuery).GetTypeInfo().Assembly);
            services.AddSwaggerGen();
            services.AddTransient<IHashingService, HashingService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IBearerTokenService, BearerTokenService>();
            services.Configure<JWTOptions>(configuration.GetSection(JWTOptions.JWT));
            services.AddSodaCompanyBearerAuthorization(configuration);
            return services;
        }
        public static IServiceCollection AddSodaCompanyBearerAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            var JWTOptions = new JWTOptions();
            configuration.GetSection(JWTOptions.JWT).Bind(JWTOptions);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                           .AddJwtBearer(options =>
                           {
                               options.TokenValidationParameters = new TokenValidationParameters
                               {
                                   ValidateIssuer = false,
                                   ValidateAudience = false,
                                   ValidateLifetime = false,
                                   ValidateIssuerSigningKey = true,
                                   ValidIssuer = JWTOptions.Issuer,
                                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTOptions.Key))
                               };

                           });
            return services;
        }
    }
}
