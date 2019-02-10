using System.Collections.Generic;
using Pedido.Dominio.Fabrica;
using Pedido.Dominio.Interface;

namespace Pedido.Dominio.Servico
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
