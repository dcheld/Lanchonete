using Pedido.Dominio.Dominio;
using Pedido.Dominio.Interface;
using System.Linq;

namespace Pedido.Dominio.Servico
{
    public class PromocaoItemMuitoQueijo : IPromocaoItem
    {
        private Pedido pedido;
        private LancheItem pedidoItemQueijo;

        public int IdPromocao => 3;
        public decimal Desconto { get; private set; }

        public void Registrar(Pedido pedido)
        {
            this.pedido = pedido;
            QuantidadeQueijo();
            if (pedidoItemQueijo.Quantidade >= 3)
                pedido.AdicionarPromocao(this);
        }

        private void QuantidadeQueijo()
        {
            var idIngredienteCarne = (int)IngredienteEnum.Queijo;
            pedidoItemQueijo = pedido.PedidoItens.FirstOrDefault(c => c.Ingrediente.Id == idIngredienteCarne);
        }

        public void Calcular()
        {
            var quantidadePromocao = pedidoItemQueijo.Quantidade / 3;
            Desconto = quantidadePromocao * pedidoItemQueijo.Ingrediente.Valor;
        }
    }
}