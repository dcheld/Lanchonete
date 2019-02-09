using Pedido.Dominio.Dominio;
using Pedido.Dominio.Interface;
using System.Linq;

namespace Pedido.Dominio.Servico
{
    public class PromocaoItemMuitoQueijo : IPromocaoItem
    {
        private Pedido pedido;
        private PedidoItem pedidoItemCarne;

        public int IdPromocao => 3;
        public decimal Desconto { get; private set; }

        public void Calcular(Pedido pedido)
        {
            this.pedido = pedido;
            QuantidadeCarne();
            Valor();
        }

        private void QuantidadeCarne()
        {
            var idIngredienteCarne = (int)IngredienteEnum.Queijo;
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