﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Pedido.Dominio.Fabrica
{
    public static class PedidoFactory
    {
        public static IList<Pedido> PedidosFeitos { get; private set; } = new List<Pedido>();

        public static void Inserir(Pedido pedido) => PedidosFeitos.Add(pedido);

    }
}
