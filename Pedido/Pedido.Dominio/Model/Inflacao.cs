namespace Pedido.Dominio
{
    public class Inflacao
    {
        public decimal PorcentagemInflacao { get; private set; }
        public decimal Valor { get; set; }

        public Inflacao()
        {
        }

        public Inflacao(decimal porcentagemInflacao)
        {
            PorcentagemInflacao = porcentagemInflacao;
        }

        public void Calcular(Pedido pedido)
        {
            Valor = pedido.Total * PorcentagemInflacao;
        }
    }
}