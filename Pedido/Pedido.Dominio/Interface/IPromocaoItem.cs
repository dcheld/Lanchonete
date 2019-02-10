namespace Pedido.Dominio.Interface
{
    public interface IPromocaoItem
    {
        int IdPromocao { get; }

        decimal Desconto { get; }

        void Registrar(Pedido pedido);

        void Calcular();
    }
}