using System.Reflection;
using APPLICATION.Mappers;
using APPLICATION.Services.Clientes;
using APPLICATION.Services.Excel;
using APPLICATION.Services.Seguros;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APPLICATION.Extensions;
 
public static class InjectionExtensions
{
        public static  IServiceCollection AddInjectionAplication(this IServiceCollection  services, IConfiguration _configuration)
        {
                services.AddSingleton(_configuration);
                services.AddFluentValidation(option =>
                {
                        option.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()
                                .Where(p => !p.IsDynamic));
                });
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddTransient<IClienteServices, ClienteServices>();
        services.AddTransient<ISeguroServices, SeguroServices>();
        services.AddTransient<IExcelService, ExcelService>();
        

        return services;
        }
}