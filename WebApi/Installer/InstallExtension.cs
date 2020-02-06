using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Installer
{
    public static class InstallExtension
    {
       public static void InstallServiceAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var InstallerClasses = typeof(Startup).Assembly.ExportedTypes.Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsAbstract && !x.IsInterface).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();
            InstallerClasses.ForEach(x => x.InstallServices(services, configuration));
        }
    }
}
