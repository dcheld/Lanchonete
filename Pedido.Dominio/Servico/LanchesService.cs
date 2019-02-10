using Pedido.Dominio.Interface;
using System.Collections.Generic;

namespace Pedido.Dominio.Servico
{
    public class LancheService : ILancheService
    {
        public IList<Lanche> ObterLanches()
        {
            return new List<Lanche>()
            {
                LancheFactory.XBacon(),
                LancheFactory.XBurger(),
                LancheFactory.XEgg(),
                LancheFactory.XEggBacon(),
            };
        }

        public IList<LancheItem> ObterLancheItem()
        {
            return LancheItemFactory.Todos();
        }
    }
}