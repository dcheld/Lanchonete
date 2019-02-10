using Pedido.Dominio.Dominio;
using Pedido.Dominio.Interface;
using System.Linq;

namespace Pedido.Dominio.Servico
{
    public class PromocaoItemMuitaCarne : IPromocaoItem
    {
        public int IdPromocao => 2;
        private Pedido pedido;

        private LancheItem pedidoItemCarne;

        public decimal Desconto { get; private set; }

        public void Registrar(Pedido pedido)
        {
            this.pedido = pedido;
            QuantidadeCarne();
            if (pedidoItemCarne.Quantidade >= 3)
                pedido.AdicionarPromocao(this);
        }

        private void QuantidadeCarne()
        {
            var idIngredienteCarne = (int)IngredienteEnum.Carne;
            pedidoItemCarne = pedido.PedidoItens.FirstOrDefault(c => c.Ingrediente.Id == idIngredienteCarne);
        }

        public void Calcular()
        {
            var quantidadePromocao = pedidoItemCarne.Quantidade / 3;
            Desconto = quantidadePromocao * pedidoItemCarne.Ingrediente.Valor;
        }
    }
}