using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SodaCompany.Application.Extensions;

namespace SodaCompany.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public const string AllowFrontendCorsPolicy = "AllowFrontendCorsPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddSodaCompanyDBService(Configuration);
            services.AddSodaCompanyServices(Configuration);
            services.AddSodaCompanyRepositories();
            services.AddCors(options =>
            {
                options.AddPolicy(AllowFrontendCorsPolicy, builder =>
                {
                    builder.WithOrigins(Configuration["FrontendOrigin"]);
                    builder.AllowAnyHeader();
                    builder.AllowCredentials();
                    builder.AllowAnyMethod();
                });
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.CheckConsentNeeded = context => true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI();



            app.UseRouting();

            app.UseCors(AllowFrontendCorsPolicy);

            app.UseAuthorization();

            app.UseCors(AllowFrontendCorsPolicy);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
