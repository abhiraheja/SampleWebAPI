using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbLayer.DbServices;
using DbLayer.Framework;
using DbLayer.Framework.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Installer
{
    public class DatabaseInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbEntity>(options => options.UseSqlServer(configuration.GetConnectionString("DbConnection")));

            services.AddScoped<IDbEntity, DbEntity>();
            services.AddScoped<IIdentityService, IdentityService>();


            
        }
    }
}
