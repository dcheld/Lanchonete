using System;

namespace Pedido.Dominio
{
    public class LancheItem
    {
        public Ingrediente Ingrediente { get; private set; }
        public int Quantidade { get; private set; }
        public decimal Valor { get; private set; }

        public LancheItem(int id, string nome, decimal valor, int quantidade = 1) :
            this(new Ingrediente(id, nome, valor), quantidade)
        {
        }

        public LancheItem(Ingrediente ingrediente) :
            this(ingrediente, 1)
        {
        }

        public LancheItem(Ingrediente ingrediente, int quantidade)
        {
            Ingrediente = ingrediente;
            Quantidade = quantidade;
        }

        public void Adicionar(int quantidade)
        {
            if (quantidade > 0)
                Quantidade += quantidade;
        }

        public void Remover(int quantidade)
        {
            Quantidade = Math.Max(0, Quantidade - Math.Abs(quantidade));
        }

        public void Calcular()
        {
            Valor = Ingrediente.Valor * Quantidade;
        }
    }
}