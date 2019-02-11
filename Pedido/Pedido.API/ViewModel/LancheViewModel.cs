using System.Collections.Generic;

namespace Pedido.API.Model
{
    public class LancheViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IList<LancheItemViewModel> LancheItens { get; set; }
    }
}