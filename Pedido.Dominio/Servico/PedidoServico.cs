using Pedido.Dominio.Interface;

namespace Pedido.Dominio.Servico
{
    public class PedidoServico : IPedidoService  
    {
        private readonly IPromocaoCalculadora promocaoCalculadora;

        public PedidoServico(IPromocaoCalculadora promocaoService)
        {
            this.promocaoCalculadora = promocaoService;
        }
        public void FecharPedido(Pedido pedido, Inflacao inflacao)
        {
            promocaoCalculadora.Calcular(pedido);
            pedido.Aplicar(inflacao);
            pedido.Calcular();
        }
    }
}
