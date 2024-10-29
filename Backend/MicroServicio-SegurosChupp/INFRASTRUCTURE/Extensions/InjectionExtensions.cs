using INFRASTRUCTURE.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INFRASTRUCTURE.Persistence.UnitOfWork;

namespace INFRASTRUCTURE.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfraestruture(this IServiceCollection service, IConfiguration configuration)
        {
            var assembly = typeof(Schupp2024Context).Assembly.FullName;

            service.AddDbContext<Schupp2024Context>(
                option => option.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(assembly)
             ) , ServiceLifetime.Transient );
            service.AddTransient<IUnitOfWork, UnitofWork>();
            return service;
        }
    }
}
