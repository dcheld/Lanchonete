using Microsoft.Extensions.DependencyInjection;
using Pedido.Dominio.Interface;

namespace Pedido.Dominio.Servico.Registrar
{
    public static class RegistrarServicesExtensao
    {
        public static IServiceCollection LanchoneServico(this IServiceCollection services)
        {
            services.AddScoped<IPedidoService, PedidoServico>();
            services.AddScoped<ILancheService, LancheService>();
            
            services.AddScoped<IPromocaoCalculadora, PromocaoCalculadora>();
            services.AddScoped<IPromocaoItem, PromocaoItemLight>();

            services.AddScoped<IPromocaoItem, PromocaoItemMuitaCarne>();
            services.AddScoped<IPromocaoItem, PromocaoItemMuitoQueijo>();
            services.AddScoped(f => f.GetServices<IPromocaoItem>());

            return services;
        }
    }
}