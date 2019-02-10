using System.Collections.Generic;

namespace Pedido.Dominio.Interface
{
    public interface IPedidoService
    {
        void FecharPedido(Pedido pedido, Inflacao inflacao);

        IEnumerable<Pedido> ObterPedidos();
    }
}