using Microsoft.Extensions.DependencyInjection;
using Pedido.Dominio.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Pedido.Dominio.Servico.Registrar
{
    public static class RegistrarServicesExtensao
    {
        public static IServiceCollection LanchoneServico(this IServiceCollection services)
        {
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IPromocaoCalculadora, PromocaoCalculadora>();
            services.AddScoped<ILancheService, LancheService>();
            
            services.AddScoped<IPromocaoCalculadora, PromocaoCalculadora>();
            services.AddScoped<IPromocaoItem, PromocaoItemLight>();

            services.AddScoped<IPromocaoItem, PromocaoItemMuitaCarne>();
            services.AddScoped<IPromocaoItem, PromocaoItemMuitoQueijo>();
            services.AddScoped<IList<IPromocaoItem>>(f => f.GetServices<IPromocaoItem>().ToList());

            return services;
        }
    }
}