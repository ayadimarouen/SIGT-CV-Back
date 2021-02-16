using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SIGT.DTO;
using SIGT.EFCore;
using SIGT.EFCore.Repositories;
using SIGT.Entities;
using SIGT.Infrastructure;
using SIGT.Infrastructure.IRepositories;
using SIGT.Infrastructure.IServices;
using SIGT.Services;

namespace SIGT.DIContainerCore
{
    public static class ContainerExtension
    {
        public static void Initialize(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SigtContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IDataBaseInitializer, DataBaseInitializer>();
            services.AddTransient<ICvRepository<Cv>, CvRepository>();
            services.AddTransient<ICvService<CvDTO>, CvService>();
    
        }
    }
}
