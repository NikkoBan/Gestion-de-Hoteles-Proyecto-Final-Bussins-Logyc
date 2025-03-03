
using GestionDhotelesPercistence.Interfaces;
using GestionDhotelesPercistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GestionDhotelesIOC.Dependencies
{
    public static class ClienteDepedency
    {
        public static void AddClienteDepedency(this IServiceCollection services)
        {
            services.AddScoped<IClientesRepository, ClienteRepository>();
        }
    }
}
