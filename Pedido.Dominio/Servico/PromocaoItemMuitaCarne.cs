using System;
using System.Linq;
using Pedido.Dominio.Dominio;
using Pedido.Dominio.Interface;

namespace Pedido.Dominio.Servico
{
    public class PromocaoItemMuitaCarne : IPromocaoItem
    {
        public int IdPromocao => 2;
        private Pedido pedido;

        private PedidoItem pedidoItemCarne;

        public decimal Desconto { get; private set; }

        public void Calcular(Pedido pedido)
        {
            this.pedido = pedido;
            QuantidadeCarne();
            Valor();
        }

        private void QuantidadeCarne()
        {
            var idIngredienteCarne = (int)IngredienteEnum.Carne;
            pedidoItemCarne = pedido.PedidoItens.FirstOrDefault(c => c.Ingrediente.Id == idIngredienteCarne);
        }

        private void Valor()
        {
            if (pedidoItemCarne != null)
            {
                var quantidadePromocao = pedidoItemCarne.Quantidade / 3;
                Desconto = quantidadePromocao * pedidoItemCarne.Ingrediente.Valor;
            }
        }
    }
}