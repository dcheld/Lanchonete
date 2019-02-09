using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.ObjectModel;

namespace Pedido.Dominio
{
    public class Lanche
    {
        public int Id { get; set; }

        public string Nome { get; private set; }
        
        public IReadOnlyList<Ingrediente> Ingredientes { get; private set; }

        public Lanche(int id, string nome, IList<Ingrediente> ingredientes)
        {
            Id = id;
            Nome = nome;
            Ingredientes = new ReadOnlyCollection<Ingrediente>(ingredientes);
        }
    }
}
