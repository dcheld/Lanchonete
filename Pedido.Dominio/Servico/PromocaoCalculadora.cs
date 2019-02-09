using Pedido.Dominio.Interface;
using System.Collections.Generic;

namespace Pedido.Dominio.Servico
{
    internal class PromocaoCalculadora : IPromocaoCalculadora
    {
        private readonly IEnumerable<IPromocaoItem> promocoesItens;

        public PromocaoCalculadora(IEnumerable<IPromocaoItem> promocoesItens)
        {
            this.promocoesItens = promocoesItens;
        }
        public void Calcular(Pedido pedido)
        {
            foreach (var promocaoItem in promocoesItens)
                promocaoItem.Calcular(pedido);
        }
    }
}
