using System.Collections.Generic;
using Pedido.Dominio.Interface;

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
    }
}