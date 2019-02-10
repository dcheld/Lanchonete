using System.Collections.Generic;

namespace Pedido.API.Model
{
    public class LancheModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IList<LancheItemModel> LancheItens { get; set; }
    }
}