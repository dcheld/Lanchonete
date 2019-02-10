using System;
using System.Collections.Generic;
using System.Text;

namespace Pedido.Dominio.Fabrica
{
    public static class InflacaoFactory
    {
        public static Inflacao ObterInflacao() => new Inflacao(0);
    }
}
