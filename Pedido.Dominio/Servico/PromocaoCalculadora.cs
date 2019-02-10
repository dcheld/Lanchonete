using Pedido.Dominio.Interface;
using System.Collections.Generic;

namespace Pedido.Dominio.Servico
{
    public class PromocaoCalculadora : IPromocaoCalculadora
    {
        private readonly IList<IPromocaoItem> promocoesItens;

        public PromocaoCalculadora(IList<IPromocaoItem> promocoesItens)
        {
            this.promocoesItens = promocoesItens;
        }
        public void Registrar(Pedido pedido)
        {
            foreach (var promocaoItem in promocoesItens)
                promocaoItem.Registrar(pedido);
        }
    }
}
