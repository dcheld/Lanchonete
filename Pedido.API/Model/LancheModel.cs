using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedido.API.Model
{
    public class LancheModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IList<LancheItemModel> LancheItens { get; set; }
    }
}
