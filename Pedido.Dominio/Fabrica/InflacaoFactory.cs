namespace Pedido.Dominio.Fabrica
{
    public static class InflacaoFactory
    {
        public static Inflacao ObterInflacao() => new Inflacao(0);
    }
}