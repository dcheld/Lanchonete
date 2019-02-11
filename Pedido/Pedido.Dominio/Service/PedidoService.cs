using Pedido.Dominio.Fabrica;
using Pedido.Dominio.Interface;
using System.Collections.Generic;

namespace Pedido.Dominio.Service
{
    public class PedidoService : IPedidoService
    {
        private readonly IPromocaoCalculadora promocaoCalculadora;

        public PedidoService(IPromocaoCalculadora promocaoService)
        {
            this.promocaoCalculadora = promocaoService;
        }

        public void FecharPedido(Pedido pedido, Inflacao inflacao)
        {
            promocaoCalculadora.Registrar(pedido);
            pedido.Aplicar(inflacao);
            pedido.Calcular();

            PedidoFactory.Inserir(pedido);
        }

        public IEnumerable<Pedido> ObterPedidos()
        {
            return PedidoFactory.PedidosFeitos;
        }
    }
}