using Pedido.Dominio.Dominio;
using Pedido.Dominio.Interface;
using System.Linq;

namespace Pedido.Dominio.Servico
{
    public class PromocaoItemLight : IPromocaoItem
    {
        private Pedido pedido;
        private decimal Percentual = 0.1m;

        public int IdPromocao => 1;
        public decimal Desconto { get; private set; }

        public void Registrar(Pedido pedido)
        {
            this.pedido = pedido;
            if (TemAlface() && !TemBacon())
                pedido.AdicionarPromocao(this);
        }

        private bool TemAlface()
        {
            int idIngredienteAlface = (int)IngredienteEnum.Alface;
            return pedido.PedidoItens.Any(item => item.Ingrediente.Id == idIngredienteAlface);
        }

        private bool TemBacon()
        {
            int idIngredienteBacon = (int)IngredienteEnum.Bacon;
            return pedido.PedidoItens.Any(item => item.Ingrediente.Id == idIngredienteBacon);
        }

        public void Calcular()
        {
            Desconto = pedido.Itens * Percentual;
        }
    }
}