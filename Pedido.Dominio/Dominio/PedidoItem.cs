using System;

namespace Pedido.Dominio
{
    public class PedidoItem
    {
        public Ingrediente Ingrediente { get; private set; }
        public int Quantidade { get; private set; } = 1;
        public decimal Valor { get; private set; }

        public PedidoItem(Ingrediente ingrediente)
        {
            Ingrediente = ingrediente;
        }

        public PedidoItem(Ingrediente ingrediente, int quantidade)
        {
            Ingrediente = ingrediente;
            Quantidade = quantidade;
        }


        public void Adicionar(int quantidade)
        {
            if(quantidade > 0)
                Quantidade += quantidade;
        }

        public void Remover(int quantidade)
        {
            Quantidade = Math.Max(0 , Quantidade - Math.Abs(quantidade));
        }

        public void Calcular()
        {
            Valor = Ingrediente.Valor * Quantidade;
        }
    }
}
