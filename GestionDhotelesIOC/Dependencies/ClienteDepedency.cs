using GestionDhoteles.Aplication.Interfaces;
using GestionDhoteles.Aplication.Services;
using GestionDhotelesPercistence.Interfaces;
using GestionDhotelesPercistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GestionDhotelesIOC.Dependencies
{
    public static class ClienteDepedency
    {
        public static void AddClienteDependency(this IServiceCollection services)
        {
            services.AddScoped<IClientesRepository, ClienteRepository>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IClienteMapper, ClienteMapper>();
        }
    }
}

