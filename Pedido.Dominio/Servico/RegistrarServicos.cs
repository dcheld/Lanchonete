using Microsoft.Extensions.DependencyInjection;
using Pedido.Dominio.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Pedido.Dominio.Servico.Registrar
{
    public static class RegistrarServicosExtensao
    {
        public static IServiceCollection LanchoneServico(this IServiceCollection services)
        {
            services.AddScoped<IPedidoService, PedidoServico>();
            services.AddScoped<IPromocaoCalculadora, PromocaoCalculadora>();
            services.AddScoped<IPromocaoItem, PromocaoItemLight>();

            services.AddScoped<IPromocaoItem, PromocaoItemMuitaCarne>();
            services.AddScoped<IPromocaoItem, PromocaoItemMuitoQueijo>();
            services.AddScoped(f => f.GetServices<IPromocaoItem>());

            return services;
        }
    }
}
