namespace Pedido.Dominio.Interface
{
    internal interface IPromocaoItem
    {
        int IdPromocao { get; }

        decimal Desconto { get; }

        void Calcular(Pedido pedido);
    }
}
