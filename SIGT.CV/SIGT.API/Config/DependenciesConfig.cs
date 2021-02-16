using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using SIGT.DIContainerCore;

namespace SIGT.API.Config
{
    public class DependenciesConfig
    {
        public static void ConfigureDependencies(IServiceCollection services, string connectionString)
        {
            ContainerExtension.Initialize(services, connectionString);
        }
    }
}
