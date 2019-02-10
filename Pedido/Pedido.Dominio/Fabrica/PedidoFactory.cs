using System.Collections.Generic;

namespace Pedido.Dominio.Fabrica
{
    public static class PedidoFactory
    {
        public static IList<Pedido> PedidosFeitos { get; private set; } = new List<Pedido>();

        public static void Inserir(Pedido pedido) => PedidosFeitos.Add(pedido);
    }
}