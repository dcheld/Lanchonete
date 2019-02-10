using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedido.API.Model
{
    public class LancheItemModel
    {
        public IngredienteModel Ingrediente { get; set; }
        public int Quantidade { get; set; }
    }
}
