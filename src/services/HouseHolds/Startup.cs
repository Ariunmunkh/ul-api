using Infrastructure.ServiceDiscovery;
using Infrastructure.ESwagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HouseHolds.Repositories;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using BaseLibrary.LConnection;
using HouseHolds.Middleware;

namespace HouseHolds
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureConsul(services);
            services.AddTransient<IBaseRepository, BaseRepository>();
            services.AddTransient<ICoachRepository, CoachRepository>();
            services.AddTransient<IHouseHoldsRepository, HouseHoldsRepository>();
            services.AddScoped(service => new DWConnector());
            services.ConfigureSwagger("HouseHolds", "v1");
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<MConnection>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(c => { });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HouseHolds");
            });

            app.UseMvc();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureConsul(IServiceCollection services)
        {
            var serviceConfig = Configuration.GetServiceConfig();
            services.RegisterConsulServices(serviceConfig);
        }
    }
}
