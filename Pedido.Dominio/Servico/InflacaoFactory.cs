using System;
using System.Collections.Generic;
using System.Text;

namespace Pedido.Dominio.Servico
{
    public static class InflacaoFactory
    {
        public static Inflacao ObterInflacao() => new Inflacao(0);
    }
}
