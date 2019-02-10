using System;
using System.Collections.Generic;
using System.Text;

namespace Pedido.Dominio.Interface
{
    public interface ILancheService
    {
        IList<Lanche> ObterLanches();
    }
}
