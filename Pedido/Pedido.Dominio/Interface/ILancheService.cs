using System.Collections.Generic;

namespace Pedido.Dominio.Interface
{
    public interface ILancheService
    {
        IList<Lanche> ObterLanches();

        IList<LancheItem> ObterLancheItem();
    }
}