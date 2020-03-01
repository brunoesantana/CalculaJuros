using CalculaJuros.Business;
using CalculaJuros.Business.Interface;
using CalculaJuros.Data.Context;
using CalculaJuros.Data.Interface;
using CalculaJuros.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CalculaJuros.Api.Injections
{
    public static class Dependency
    {
        public static void AddDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped<ICalculoService, CalculoService>();
            services.AddScoped<ICalculoRepository, CalculoRepository>();
            services.AddScoped<IProjetoService, ProjetoService>();
            services.AddScoped<IProjetoRepository, ProjetoRepository>();
            services.AddSingleton<DataContext>();
        }
    }
}
