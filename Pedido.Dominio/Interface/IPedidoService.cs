namespace Pedido.Dominio.Interface
{
    public interface IPedidoService
    {
        void FecharPedido(Pedido pedido, Inflacao inflacao);
    }
}
