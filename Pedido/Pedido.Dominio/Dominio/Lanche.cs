using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pedido.Dominio
{
    public class Lanche
    {
        public int Id { get; private set; }

        public string Nome { get; private set; }

        public IReadOnlyList<LancheItem> LancheItens { get; private set; }

        public Lanche()
        {
        }

        public Lanche(int id, string nome, IList<LancheItem> ingredientes)
        {
            Id = id;
            Nome = nome;
            LancheItens = new ReadOnlyCollection<LancheItem>(ingredientes);
        }
    }
}