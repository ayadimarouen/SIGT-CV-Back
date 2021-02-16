using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Configuration;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using SIGT.API.Config;
using SIGT.API.Setup;

namespace SIGT.API
{
    public class Startup
    {
        protected IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected void ConfigureDependencies(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("Sigt");
            DependenciesConfig.ConfigureDependencies(services, connectionString);

        }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            ConfigureDependencies(services);
            services.ConfigureSwagger();
            
            services.ConfigureCors();   

        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            
            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();
                      
            app.UseConfiguredSwagger();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                
            });
        }

    }
}
