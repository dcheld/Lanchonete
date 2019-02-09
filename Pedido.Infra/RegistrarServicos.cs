using Microsoft.Extensions.DependencyInjection;
using Pedido.Dominio.Interface;

namespace Pedido.Infra
{
    public static class RegistrarServicos
    {
        public static IServiceCollection LanchonetInfra(this IServiceCollection services)
        {
            services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
            
            return services;
        }
    }
}
